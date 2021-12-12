using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jaguar.BaseObject;
using Oracle.ManagedDataAccess.Client;
using Jaguar.Misc;
using Jaguar.Action;

namespace Jaguar.Forms
{
    public partial class Frm_invoiceLog : BaseDialog
    {
        private string s_fa001 = string.Empty;   //结算流水号
        private string s_fa190 = string.Empty;
        private string s_fa195 = string.Empty;
 
        public Frm_invoiceLog()
        {
            InitializeComponent();
            
        }

        private void Frm_invoiceLog_Load(object sender, EventArgs e)
        {
            s_fa001 = this.swapdata["fa001"].ToString();
            te_fa001.Text = s_fa001;
 
            using(OracleDataReader reader = SqlAssist.ExecuteReader("select * from fa01 where fa001='" + s_fa001 + "'"))
            {
                if (reader.Read())
                {
                    s_fa190 = reader["FA190"].ToString();
                    s_fa195 = reader["FA195"].ToString();
                    te_fa003.Text = reader["FA003"].ToString();

                    //计算财政票据金额
                    te_fin.Text = SqlAssist.ExecuteScalar("select nvl(sum(sa007),0) from v_sa01 where sa020 ='F' and sa010 ='" + s_fa001 + "'").ToString();
                    //计算税务票据金额
                    te_tax.Text = SqlAssist.ExecuteScalar("select nvl(sum(sa007),0) from v_sa01 where sa020 ='T' and sa010 ='" + s_fa001 + "'").ToString();

                    if (!s_fa190.Equals(s_fa195))  //应开、已开不相等
                    {
                        if(s_fa195.Substring(0,1) == s_fa190.Substring(0, 1))
                        {
                            xtraTabPage1.PageEnabled = false;
                        }
                        else
                        {
                            //te_pjlx.Text = Envior.FIN_INVOICE_TYPE;  //财政票据类型
                            //te_zch.Text = GetZch();
                        }
 
                        if(s_fa195.Substring(1,1) == s_fa190.Substring(1, 1))
                        {
                            xtraTabPage2.PageEnabled = false;
                        }
                        else
                        {
                            te_tax_code.Text = GetFPDM();
                        }

                        if (!xtraTabPage1.PageEnabled && xtraTabPage2.PageEnabled) xtraTabControl1.SelectedTabPage = xtraTabPage2;
                         
                    }
                    else
                    {
                        xtraTabPage1.PageEnabled = false;
                        xtraTabPage2.PageEnabled = false;
                        b_ok.Enabled = false;
                    }
                }
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            string s_fin_pjlx = string.Empty;
            string s_fin_zch = string.Empty;
            string s_fin_fph = string.Empty;

            string s_fpdm = string.Empty;
            string s_fph = string.Empty;
            //1.输入完整性检查!!!
            if (xtraTabPage1.PageEnabled)
            {
                if (string.IsNullOrEmpty(te_pjlx.Text))
                {
                    te_pjlx.ErrorText = "财政票据类型不能为空!";
                    te_pjlx.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
                    te_pjlx.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(te_zch.Text))
                {
                    te_zch.ErrorText = "发票注册号不能为空!";
                    te_zch.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
                    te_zch.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(te_fph.Text))
                {
                    te_fph.ErrorText = "财政发票号不能为空!";
                    te_fph.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
                    te_fph.Focus();
                    return;
                }
                s_fin_pjlx = te_pjlx.Text;
                s_fin_zch = te_zch.Text;
                s_fin_fph = te_fph.Text;
            }
            if (xtraTabPage2.PageEnabled)
            {
                if (string.IsNullOrEmpty(te_tax_code.Text))
                {
                    te_tax_code.ErrorText = "税务发票代码不能为空!";
                    te_tax_code.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
                    te_tax_code.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(te_tax_ph.Text))
                {
                    te_tax_ph.ErrorText = "税务发票号不能为空!";
                    te_tax_ph.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
                    te_tax_ph.Focus();
                    return;
                }
                s_fpdm = te_tax_code.Text;
                s_fph = te_tax_ph.Text;
            }

            //2. 补充财政发票日志
            int result = 0;
            if (xtraTabPage1.PageEnabled)
            {
                result = MiscAction.FinReLog(s_fa001, s_fin_pjlx, s_fin_zch, s_fin_fph);
                if (result < 0) return;
                XtraMessageBox.Show("财政发票日志记录成功!","提示");
            }
            if (xtraTabPage2.PageEnabled)
            {
                result = MiscAction.TaxReLog(s_fa001, s_fpdm, s_fph);
                if (result < 0) return;
                XtraMessageBox.Show("税务发票日志记录成功!", "提示");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
 
        }

        /// <summary>
        /// 获取当前工作站 财政注册号
        /// </summary>
        /// <returns></returns>
        private string GetZch()
        {
            OracleParameter op_ws001 = new OracleParameter("ws001", OracleDbType.Varchar2, 10);
            op_ws001.Value = Envior.WORKSTATIONID;
            object value = SqlAssist.ExecuteScalar("select INVOICEZCH from fin_log where ws001 = :ws001 and to_char(kprq,'yyyy-mm-dd') >= to_char(sysdate - 3,'yyyy-mm-dd') and rownum < 2", new OracleParameter[] { op_ws001 });
            if (value == null || value is DBNull)
                return "";
            else
                return value.ToString();
        }

        /// <summary>
        /// 获取税务发票代码
        /// </summary>
        /// <returns></returns>
        private string GetFPDM()
        {
            OracleParameter op_ws001 = new OracleParameter("ws001", OracleDbType.Varchar2, 10);
            op_ws001.Value = Envior.WORKSTATIONID;
            object value = SqlAssist.ExecuteScalar("select INVOICECODE from tax_log where ws001 = :ws001 and to_char(INVOICEDATE,'yyyy-mm-dd') >= to_char(sysdate - 3,'yyyy-mm-dd') and rownum < 2", new OracleParameter[] { op_ws001 });
            if (value == null || value is DBNull)
                return "";
            else
                return value.ToString();
        }
    }
}