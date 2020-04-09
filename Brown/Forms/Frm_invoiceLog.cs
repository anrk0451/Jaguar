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
using Brown.BaseObject;
using Oracle.ManagedDataAccess.Client;
using Brown.Misc;

namespace Brown.Forms
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
                            te_pjlx.Text = Envior.FIN_INVOICE_TYPE;  //财政票据类型
                        }
 
                        if(s_fa195.Substring(1,1) == s_fa190.Substring(1, 1))
                        {
                            xtraTabPage2.PageEnabled = false;
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
    }
}