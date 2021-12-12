﻿using System;
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
using Jaguar.Action;
using Jaguar.Misc;
using Jaguar.Domain;
using Jaguar.Dao;
using System.IO;

namespace Jaguar.Forms
{
    public partial class Frm_registerOut : BaseDialog
    {
        private string rc001 = string.Empty;
        private decimal price = decimal.Zero;  //寄存单价
        private bool isrefund = false;         //是否退费
		 
		public Frm_registerOut()
        {
            InitializeComponent();
        }

		private void Frm_registerOut_Load(object sender, EventArgs e)
		{
			rc001 = this.swapdata["RC001"].ToString();

			OracleDataReader reader = SqlAssist.ExecuteReader("select * from rc01 where rc001='" + rc001 + "'");
			while (reader.Read())
			{
				txtEdit_rc001.Text = rc001;
				txtEdit_rc109.EditValue = reader["RC109"];
				txtEdit_rc003.EditValue = reader["RC003"];
				txtEdit_rc303.EditValue = reader["RC303"];
				rg_rc002.EditValue = reader["RC002"];
				rg_rc202.EditValue = reader["RC202"];
				txtEdit_rc004.EditValue = reader["RC004"];
				txtEdit_rc404.EditValue = reader["RC404"];
				txtEdit_rc150.EditValue = reader["RC150"];   //寄存到期日期
				be_position.EditValue = RegisterAction.GetRegPathName(rc001);

				price = Math.Round(  RegisterAction.GetBitPrice(reader["RC130"].ToString()) / 12, 0);
				txtEdit_price.EditValue = price;

				int diff = RegisterAction.CalcOutDiffDays(rc001);

				int compare = string.Compare(Convert.ToDateTime(reader["RC150"]).ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"));
				if (compare == 0)
				{
					checkEdit1.Enabled = false;
					txtEdit_nums.Enabled = false;
				}
				else if (compare > 0)  //退费
				{
					//lc_1.Text = "剩余天数";
					//lc_2.Text = "应退费月数";
					//lc_3.Text = "退费金额";
					//isrefund = true;

					//txtEdit_nums.EditValue = Math.Round((diff * 1.0f) / 30, 0);
					//txtEdit_fee.EditValue = Convert.ToDecimal(Math.Round((diff * 1.0f) / 30, 0)) * price;

					txtEdit_nums.EditValue = 0;
					txtEdit_fee.EditValue = 0;
				}
				else
				{
					lc_1.Text = "过期天数";
					lc_2.Text = "应补费月数";
					lc_3.Text = "补费金额";

					txtEdit_nums.EditValue = Math.Round((diff * 1.0f) / 30, 0);
					txtEdit_fee.EditValue = Convert.ToDecimal(Math.Round((diff * 1.0f) / 30, 0)) * price;
				}				 
				txtEdit_diff.EditValue = diff;
			}

			//TODO 5. 根据权限设置 是否允许补退费
			//权限检查
			if (!AppAction.CheckRight("迁出时允许选择补退")) 
				checkEdit1.Enabled = false;

		}


		/// <summary>
		/// 是否补退费 开关
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{
			txtEdit_nums.Enabled = checkEdit1.Checked;
			if (!checkEdit1.Checked)
			{
				txtEdit_nums.Text = "0.00";
			}
		}

		/// <summary>
		/// 补退费年限校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtEdit_nums_Validating(object sender, CancelEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtEdit_nums.Text))
			{
				if (Convert.ToDecimal(txtEdit_nums.Text) < 0)
				{
					txtEdit_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtEdit_nums.ErrorText = "应为正值!";
					e.Cancel = true;
				}
			}
		}

		/// <summary>
		/// 补退费年限变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtEdit_nums_EditValueChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtEdit_nums.Text))
			{
				decimal nums = Convert.ToDecimal(txtEdit_nums.Text);
				txtEdit_fee.EditValue = Math.Round(price * nums);
			}
		}

		private void b_ok_Click(object sender, EventArgs e)
		{
			///大庆迁出只有补费，退费去日收费查询里面退		
			isrefund = false;

			if (rc001 == null)
			{
				XtraMessageBox.Show("数据传递错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (txtEdit_oc003.EditValue == null || txtEdit_oc003.EditValue is System.DBNull)
			{
				txtEdit_oc003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_oc003.ErrorText = "请输入迁出办理人!";
				return;
			}
			if (te_oc005.EditValue == null)
			{
				te_oc005.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_oc005.ErrorText = "请输入迁出原因!";
				return;
			}
			string s_oc003 = txtEdit_oc003.Text;   //迁出人
			string s_oc005 = te_oc005.Text;       //迁出原因
			string s_oc004 = txtEdit_oc004.Text;   //迁出人身份证号

			int diff = int.Parse(txtEdit_diff.EditValue.ToString());
			decimal nums = decimal.Zero;
			string fa001 = Tools.GetEntityPK("FA01");
			string last_fa001 = RegisterAction.GetREGLastSettleId(rc001);     //获取最后一次缴费 结算流水号

			//补退情况
			if (checkEdit1.Checked && (!string.IsNullOrEmpty(txtEdit_nums.Text)))
			{
				nums = decimal.Parse(txtEdit_nums.Text);
			}
			else
			{
				nums = 0;
			}

			if (XtraMessageBox.Show("确认要继续办理迁出吗？本业务将不能回退!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
			 
			int re = RegisterAction.RegisterOut(rc001,
												 s_oc003,
												 s_oc004,
												 s_oc005,
												 diff,
												 fa001,
												 price,
												 isrefund ? 0 - nums : nums,
												 Envior.cur_userId
				);
			if (re > 0)
			{
				XtraMessageBox.Show("迁出办理成功!现在打印【迁出通知单】", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PrtServAction.PrtRegisterOutNotice(rc001,this.Handle.ToInt32());

				if (!isrefund && nums  > 0)
				{
					if (XtraMessageBox.Show("现在开具【发票】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						if (FinInvoice2.Invoice(fa001) > 0)
						{
							if (XtraMessageBox.Show("现在打印财政电子票吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								FinInvoice2.CallBrowserPrint(fa001);
							}
						}
					}
				}
				else if(isrefund && Math.Abs(nums) > 0)    //退费发票
				{
					//如果是新版接口上线前开具的原发票
					if (MiscAction.FinRefundBeforeOnline(fa001))
					{
						XtraMessageBox.Show("原发票在财政新接口上线前开具,不能开具对应退费发票,请在财政发票系统内完成发票开具.\r\n 开具成功后请更新发票号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					 
					XtraMessageBox.Show("功能暂不支持!");
				}
			}
			DialogResult = DialogResult.OK;
			this.Close(); 
		}

		private void sb_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		 
	}
}