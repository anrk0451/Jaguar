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
using Jaguar.Misc;
using Jaguar.Action;
using Oracle.ManagedDataAccess.Client;

namespace Jaguar.Forms
{
    public partial class Frm_TaxBaseInfo : BaseDialog
    {
        public Frm_TaxBaseInfo()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Frm_TaxBaseInfo_Load(object sender, EventArgs e)
        {
            rg_invtype.EditValue = Envior.TAX_INVOICE_TYPE;   //发票类型
            txtedit_addr.EditValue = Envior.TAX_ADDR_TELE;    //地址电话
            txtedit_cert.EditValue = Envior.TAX_CERT_PWD;     //金税卡证书密码
            txtedit_ver.EditValue = Envior.TAX_CODE_VER;      //税务税收分类编码版本
            txtedit_bank.EditValue = Envior.TAX_BANK_ACCOUNT; //银行账号
            txt_skr.EditValue = Envior.TAX_CASHIER;           //收款人
            txt_shr.EditValue = Envior.TAX_CHECKER;           //审核人
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string s_bank_account = txtedit_bank.Text;
            string s_inv_type = rg_invtype.EditValue.ToString();
            string s_addr_tele = txtedit_addr.Text;
            string s_cert_pwd = txtedit_cert.Text;
            string s_ver = txtedit_ver.Text;
            string s_skr = txt_skr.Text;
            string s_shr = txt_shr.Text;

            OracleTransaction trans = null;
            try
            {
                trans = SqlAssist.conn.BeginTransaction();
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_addr_tele + "' where sp001 = '0000000051' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_bank_account + "' where sp001 = '0000000052' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_inv_type + "' where sp001 = '0000000054' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_cert_pwd + "' where sp001 = '0000000057' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_ver + "' where sp001 = '0000000058' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_skr + "' where sp001 = '0000000055' ");
                SqlAssist.ExecuteNonQuery_NoTans("update sp01 set sp005 ='" + s_shr + "' where sp001 = '0000000056' ");


                Envior.TAX_INVOICE_TYPE = s_inv_type;
                Envior.TAX_CERT_PWD = s_cert_pwd;
                Envior.TAX_ADDR_TELE = s_addr_tele;
                Envior.TAX_BANK_ACCOUNT = s_bank_account;
                Envior.TAX_CODE_VER = s_ver;
                Envior.TAX_CASHIER = s_skr;
                Envior.TAX_CHECKER = s_shr;

                trans.Commit();

                XtraMessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                trans.Rollback();
                XtraMessageBox.Show(ee.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

		private void sb_exit_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}