using DevExpress.XtraEditors;
using Jaguar.BaseObject;
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
	public partial class Frm_AvoidOption : BaseDialog
	{
		private DataTable dt_st01 = new DataTable("st01");
		private DataTable dt_av01 = new DataTable("av01");

		private OracleDataAdapter st01Adapter = new OracleDataAdapter("select * from st01 where st002 = 'AVOIDTYPE' and st001 > '0000000050' and status = '1' order by sortId ", SqlAssist.conn);
		private OracleDataAdapter av01Adapter = new OracleDataAdapter("select * from av01 order by av002", SqlAssist.conn);
		private OracleCommandBuilder av01builder = null;
		public Frm_AvoidOption()
		{
			InitializeComponent();
		}

		private void Frm_AvoidOption_Load(object sender, EventArgs e)
		{			 
			gridControl1.DataSource = dt_av01;
			av01Adapter.Fill(dt_av01);

			lookUpEdit1.Properties.DataSource = dt_st01;
			st01Adapter.Fill(dt_st01);
			 
			gridView1.ActiveFilter.Clear();
			gridView1.ActiveFilterString = "[AV001]='0'";

			av01builder = new OracleCommandBuilder(av01Adapter);
		}

		private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
		{
			//XtraMessageBox.Show(lookUpEdit1.EditValue.ToString());
			gridView1.ActiveFilter.Clear();
			gridView1.ActiveFilterString = "[AV001]='" + lookUpEdit1.EditValue.ToString() + "'";
		}
		/// <summary>
		/// 列名转换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if(e.Column.FieldName.ToUpper() == "AV002")
			{
				switch (e.Value.ToString())
				{
					case "s_num":
						e.DisplayText = "遗体存放-减免天数";
						break;
					case "s_price":
						e.DisplayText = "遗体存放-减免单价";
						break;
					case "c_price":
						e.DisplayText = "火化减免";
						break;
					case "h_price":
						e.DisplayText = "灵车减免";
						break;
					case "r_price":
						e.DisplayText = "骨灰寄存减免-单价";
						break;
					case "r_num":
						e.DisplayText = "骨灰寄存减免-数量";
						break;
					case "o_price":
						e.DisplayText = "其他减免项";
						break;
				}

 
				
			}
		}
		/// <summary>
		/// 校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			if (Decimal.Parse(e.Value.ToString()) < 0)
			{
				e.Valid = false;
				e.ErrorText = "数值不能小于0!";
			}
		}
		/// <summary>
		/// 保存过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void b_ok_Click(object sender, EventArgs e)
		{
			if(lookUpEdit1.EditValue == null)
			{
				XtraMessageBox.Show("请选择一个减免方案!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			if (!gridView1.PostEditor()) return;
			if (!gridView1.UpdateCurrentRow()) return;
			try
			{
				av01Adapter.Update(dt_av01);
				 
				XtraMessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			catch (Exception ee)
			{
				XtraMessageBox.Show(ee.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		
	}
}