using DevExpress.XtraEditors;
using Jaguar.BaseObject;
using Jaguar.DataSet;
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
	public partial class Frm_Room : BaseDialog
	{
		private string s_rg001 = string.Empty;
		private string s_action = string.Empty;
		private DataRow dr_room = null;
		private RGDataSet rgset = null;

		public Frm_Room()
		{
			InitializeComponent();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Frm_Room_Load(object sender, EventArgs e)
		{
			s_action = this.swapdata["action"].ToString();
			rgset = this.swapdata["dataset"] as RGDataSet;

			if (s_action == "edit")  //新增			 
			{
				s_rg001 = this.swapdata["rg001"].ToString();
				DataRow[] rows = rgset.Rg01.Select("RG001='" + s_rg001 + "'");
				if (rows.Count() > 0)
				{
					dr_room = rows[0];
					txt_rg003.Text = dr_room["RG003"].ToString();

					if (dr_room["RG055"].ToString() == "1")
						ck_rg055.Checked = true;
					else
						ck_rg055.Checked = false;
				}
				else
				{
					XtraMessageBox.Show("未找到数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					sb_ok.Enabled = false;
				}
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string s_rg003 = string.Empty;
			///输入校验
			if (String.IsNullOrEmpty(txt_rg003.Text))
			{
				txt_rg003.Focus();
				txt_rg003.ErrorText = "请输入寄存排名字!";
				return;
			}
			else
			{
				s_rg003 = txt_rg003.Text;
			}

			dr_room["RG003"] = s_rg003;
			dr_room["RG055"] = ck_rg055.Checked ? "1" : "0";

			this.swapdata["datarow"] = dr_room;
			DialogResult = DialogResult.OK;
			this.Close();

		}
	}
}