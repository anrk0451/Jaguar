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
using Jaguar.BusinessObject;
using DevExpress.XtraTreeList.Nodes;
using Jaguar.DataSet;

namespace Jaguar.Forms
{
	public partial class Frm_region : BaseDialog
	{
		private RegisterStru rs = null;
		private string s_rg001 = string.Empty;
		private string s_action = string.Empty;
		private DataRow dr_region = null;
		private RGDataSet rgset = null;

		public Frm_region()
		{
			InitializeComponent();
		}

		private void Frm_region_Load(object sender, EventArgs e)
		{
			rs = this.swapdata["bobject"] as RegisterStru;
			s_action = this.swapdata["action"].ToString();
			rgset = this.swapdata["dataset"] as RGDataSet;
			  
			if (s_action == "add")  //新增
			{
				TreeListNode parentNode = this.swapdata["pnode"] as TreeListNode;
				combo_rg030.SelectedIndex = 0;
				combo_rg033.SelectedIndex = 0;
				txt_rg003.Text = rs.GetSuggestName(parentNode, "3");

				if (!parentNode.HasChildren)
				{
					txt_rg010.Text = "1";
				}
				else
				{
					if (string.IsNullOrWhiteSpace(parentNode.LastNode.GetValue("RG011").ToString()))
						txt_rg010.Text = "1";
					else
						txt_rg010.Text = (int.Parse(parentNode.LastNode.GetValue("RG011").ToString()) + 1).ToString();
				}
			}
			else   //编辑区
			{
				s_rg001 = this.swapdata["rg001"].ToString();
				DataRow[] rows = rgset.Rg01.Select("RG001='" + s_rg001 + "'");
				if (rows.Count() > 0)
				{
					dr_region = rows[0];
					txt_rg003.Text = dr_region["RG003"].ToString();
					txt_rg020.EditValue = dr_region["RG020"];          //层数
					txt_rg020.ReadOnly = true;

					txt_rg021.EditValue = dr_region["RG021"];
					txt_rg021.ReadOnly = true;

					if (dr_region["RG055"].ToString() == "1")
						ck_rg055.Checked = true;
					else
						ck_rg055.Checked = false;

					txt_rg010.Enabled = false;
					txt_rg011.Enabled = false;
					txt_rg020.Enabled = false;
					txt_rg021.Enabled = false;
				}
				else
				{
					XtraMessageBox.Show("未找到数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					sb_ok.Enabled = false;
				}

			}
		}

		/// <summary>
		/// 确定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			string rg003 = string.Empty;
			int rg010 = 0;				   //起始号位
			 //int rg011 ;				   //终止号位
			int rg020;    //层数
			int rg021;    //每层号位数

			///输入校验
			if (String.IsNullOrEmpty(txt_rg003.Text))
			{
				txt_rg003.Focus();
				txt_rg003.ErrorText = "请输入寄存排名字!";
				return;
			}
			else
			{
				rg003 = txt_rg003.Text;
			}

			if (string.IsNullOrEmpty(txt_rg020.Text))
			{
				txt_rg020.Focus();
				txt_rg020.ErrorText = "请输入层数!";
				return;
			}
			else
			{
				rg020 = int.Parse(txt_rg020.Text);
			}

			if (string.IsNullOrEmpty(txt_rg021.Text))
			{
				txt_rg021.Focus();
				txt_rg021.ErrorText = "请输入每层号位数!";
				return;
			}
			else
			{
				rg021 = int.Parse(txt_rg021.Text);
			}
 
			//////////////////  校验结束  ///////////////////////////
			
			if(s_action == "add")
			{
				DataRow newrow = rs.GetDataset().Rg01.NewRow();
				newrow["RG001"] = Tools.GetEntityPK("RG01");
				newrow["RG002"] = "3";
				newrow["RG003"] = rg003;
				newrow["RG010"] = rg010;
				newrow["RG020"] = rg020;
				newrow["RG021"] = rg021;
				newrow["RG030"] = combo_rg030.SelectedIndex.ToString();
				newrow["RG033"] = combo_rg033.SelectedIndex.ToString();
				newrow["RG009"] = (this.swapdata["pnode"] as TreeListNode).Id;  //父节点编号			 
				newrow["STATUS"] = "1";          //状态

				rs.swapdata["nodedata"] = newrow;
				DialogResult = DialogResult.OK;
				this.Close();
			}
			else if(s_action == "edit")
			{
				dr_region["RG003"] = rg003;
				dr_region["RG055"] = ck_rg055.Checked ? "1" : "0";
				DialogResult = DialogResult.OK;
				this.Close();
			}
			
		}

		/// <summary>
		/// 起始号位校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg010_Validating(object sender, CancelEventArgs e)
		{
			//if (String.IsNullOrEmpty(txt_rg010.Text))
			//{
			//	txt_rg010.ErrorText = "请输入起始号位!";
			//	e.Cancel = true;
			//	return;
			//}
			//if (int.Parse(txt_rg010.EditValue.ToString()) <= 0)
			//{
			//	txt_rg010.ErrorText = "请输入大于0的数字!";
			//	e.Cancel = true;
			//}
		}

		/// <summary>
		/// 终止号位校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg011_Validating(object sender, CancelEventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_rg011.Text) && int.Parse(txt_rg011.Text) <= 0)
			{
				txt_rg011.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
				return;
			}
		}

		/// <summary>
		/// 层数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg020_Validating(object sender, CancelEventArgs e)
		{
			if (String.IsNullOrEmpty(txt_rg020.Text))
			{
				txt_rg020.ErrorText = "请输入层数!";
				e.Cancel = true;
				return;
			}
			if (int.Parse(txt_rg020.Text) <= 0)
			{
				txt_rg020.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 每层号位数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg021_Validating(object sender, CancelEventArgs e)
		{
			if (String.IsNullOrEmpty(txt_rg021.Text))
			{
				txt_rg021.ErrorText = "请输入每层号位数!";
				e.Cancel = true;
				return;
			}
			if (int.Parse(txt_rg021.Text) <= 0)
			{
				txt_rg021.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			Close();
		}

	 

		private void Frm_region_FormClosing(object sender, FormClosingEventArgs e)
		{   //防止无效数据时不让关闭
			txt_rg021.CausesValidation = false;
			txt_rg010.CausesValidation = false;
			txt_rg011.CausesValidation = false;
			txt_rg020.CausesValidation = false;		
		}
	}
}