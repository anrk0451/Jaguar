using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaguar.Forms
{
	public partial class Frm_SingleSideRemoved : BaseDialog
	{
		public Frm_SingleSideRemoved()
		{
			InitializeComponent();
		}

		private void b_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void b_ok_Click(object sender, EventArgs e)
		{		 
			string s_code = string.Empty;
			string s_num = string.Empty;
			string s_invtype = radioGroup1.EditValue.ToString();
			decimal dec_hjje = decimal.Zero;
			int i_count = 0;

			if (string.IsNullOrEmpty(te_code.Text))
			{
				te_code.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_code.ErrorText = "发票代码必须输入!";
				te_code.Focus();
				return;
			}
			s_code = te_code.Text;

			if (string.IsNullOrEmpty(te_num.Text))
			{
				te_num.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_num.ErrorText = "发票号必须输入!";
				te_num.Focus();
				return;
			}
			s_num = te_num.Text;

			if(s_invtype == "T")
			{
				if (string.IsNullOrEmpty(te_fa004.Text))
				{
					te_fa004.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					te_fa004.ErrorText = "发票总金额必须输入!";
					te_fa004.Focus();
					return;
				}
				dec_hjje = Convert.ToDecimal(te_fa004.Text);
			}

			OracleParameter op_invCode = new OracleParameter("invcode", OracleDbType.Varchar2, 20);
			op_invCode.Direction = ParameterDirection.Input;
			op_invCode.Value = s_code;

			OracleParameter op_invNum = new OracleParameter("invnum", OracleDbType.Varchar2, 20);
			op_invNum.Direction = ParameterDirection.Input;
			op_invNum.Value = s_num;


			if (s_invtype == "F")       
			{
				i_count = Convert.ToInt32(SqlAssist.ExecuteScalar("select count(*) from fin_log where invoicezch = :invcode and invoiceno = :invnum", new OracleParameter[] { op_invCode, op_invNum }));
			}
			else if (s_invtype == "T")  //作废税务发票
			{
				i_count = Convert.ToInt32(SqlAssist.ExecuteScalar("select count(*) from tax_log where INVOICECODE = :invcode and INVOICENUM = :invnum", new OracleParameter[] { op_invCode, op_invNum }));
			}
			if(i_count > 0)
			{
				XtraMessageBox.Show("指定的发票号已经存在!", "提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			//////作废财政发票
			if (s_invtype == "F")
			{
				if (FinInvoice.InvoiceRemoved(s_code, s_num) > 0)
					this.Close();
			}
			else if(s_invtype == "T")
			{
				if (TaxInvoice.Remove(s_code, s_num, dec_hjje, Envior.cur_userName) > 0)
					this.Close();
			}


		}
	}
}