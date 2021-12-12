using DevExpress.XtraEditors;
using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
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
	public partial class Frm_Cash : BaseDialog
	{
		private string ac001 = string.Empty;
		private string action = string.Empty;
		public Frm_Cash()
		{
			InitializeComponent();
		}

		private void b_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Frm_Cash_Load(object sender, EventArgs e)
		{
			action = this.swapdata["action"].ToString();
			ac001 = this.swapdata["ac001"].ToString();
			if (action == "pay")
			{
				this.Text = "缴纳押金";
			}
			else
			{
				this.Text = "返还押金";
				labelControl2.Text = "收款人";

				labelControl1.Text = "返还金额";
				te_cash.EditValue = 0 - FireAction.GetCash(ac001);
				te_cash.Enabled = false;
			}
		}

		private void b_ok_Click(object sender, EventArgs e)
		{
			string s_payer = te_payer.Text;
			string s_billno = te_billno.Text;
			decimal dec_cash = decimal.Zero;
			dec_cash = Convert.ToDecimal(te_cash.EditValue);
			if(dec_cash == 0)
			{
				te_cash.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_cash.ErrorText = "请输入押金金额!";
				te_cash.Focus();
				return;
			}
			if (string.IsNullOrEmpty(s_payer))
			{
				te_payer.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_payer.ErrorText = "请输入交款人!";
				te_payer.Focus();
				return;
			}

			if(FireAction.PayCash(ac001,dec_cash,s_payer,s_billno,Envior.cur_userId) > 0)
			{
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}