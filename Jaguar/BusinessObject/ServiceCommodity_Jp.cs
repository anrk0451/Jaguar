using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using Jaguar.BaseObject;
using Jaguar.DataSet;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Jaguar.BusinessObject
{
	public partial class ServiceCommodity_Jp : BaseBusiness
	{
		int curIndex = 0;
		Boolean LOCK = true;

		ServiceCommodity_ds sp_ds = new ServiceCommodity_ds();
		OracleParameter op_gi002 = null;

		public ServiceCommodity_Jp()
		{
			InitializeComponent();
		}

		private void ServiceCommodity_Jp_Load(object sender, EventArgs e)
		{
			gridControl2.DataSource = sp_ds.Gi01;
 
			op_gi002 = new OracleParameter("gi002", OracleDbType.Varchar2, 15);
			op_gi002.Direction = ParameterDirection.Input;
			sp_ds.gi01Adapter.SelectCommand.Parameters.Add(op_gi002);


			//设置初始选择
			imageListBoxControl1.SetSelected(0, true);
			curIndex = 0;

			//设置自动过滤(过滤掉删除行:此操作应该在数据集装入数据后)
			gridView2.ActiveFilter.Clear();
			gridView2.ActiveFilterString = "STATUS <> '0'";

			/// 设置排序列 
			gridView2.Columns["SORTID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
	  
			lookup_gi099.DataSource = sp_ds.Ii01;
			lookup_gi099.DisplayMember = "DISPLAY_NAME";
			lookup_gi099.ValueMember = "INVOICE_ID";
		}
		/// <summary>
		/// 绘制行号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
		{
			e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			if (e.Info.IsRowIndicator)
			{
				if (e.RowHandle >= 0)
				{
					e.Info.DisplayText = (e.RowHandle + 1).ToString();
				}
				else if (e.RowHandle < 0 && e.RowHandle > -1000)
				{
					e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
					e.Info.DisplayText = "G" + e.RowHandle.ToString();
				}
			}
		}
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			gridView2.AddNewRow();
			int rowno = gridView2.FocusedRowHandle;

			/////// 设置焦点 开始编辑 !!!		 
		    gridView2.FocusedColumn = gridView2.Columns["GI003"];
			gridView2.ShowEditor();
		}

		private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			curIndex = imageListBoxControl1.SelectedIndex;
			 

			if ( ((sp_ds.Gi01 as DataTable).GetChanges() != null) && LOCK)
			{
				if (XtraMessageBox.Show("数据已经改变,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (Save())
					{
						curIndex = imageListBoxControl1.SelectedIndex;
						 
						gridControl2.Visible = true; 
						op_gi002.Value = GetCurTypeStr(curIndex);
						sp_ds.Fill_Gi01();						 
					}
					else
					{
						LOCK = false;
						imageListBoxControl1.SetSelected(curIndex, true);
					}
				}
				else
				{
					curIndex = imageListBoxControl1.SelectedIndex;		 
					op_gi002.Value = GetCurTypeStr(curIndex);
					sp_ds.Fill_Gi01();			 
				}

			}
			else if (LOCK)
			{
				curIndex = imageListBoxControl1.SelectedIndex;			 
				op_gi002.Value = GetCurTypeStr(curIndex);
				sp_ds.Fill_Gi01();			 
			}
			else
			{
				LOCK = true;
			}
		 
		}
		private Boolean Save()
		{
			gridView2.ClearColumnErrors();
			if (!gridView2.PostEditor()) return false;
			if (!gridView2.UpdateCurrentRow()) return false;

			///完整性检查 
			DataTable dt_source = sp_ds.Gi01;
			foreach (DataRow dr in dt_source.Rows)
			{
				if (dr[2] == null || dr[2] is DBNull)
				{
					XtraMessageBox.Show("项目名称必须输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}

			///////////////////////////////////////////

			try
			{		 
				sp_ds.gi01Adapter.Update(sp_ds.Gi01);
				XtraMessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return true;
			}
			catch (Exception ee)
			{
				XtraMessageBox.Show(ee.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		////根据索引获取当前类别
		private String GetCurTypeStr(int index)
		{
			string result = string.Empty;
			switch (index)
			{
				case 0:  //谷类
					result = "20";
					break;
				case 1:  //纸类
					result = "21";
					break;
				case 2:  //祭品
					result = "22";
					break;				 
			}
			return result;
		}
		/// <summary>
		/// 新行初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
		{
			string newkey = string.Empty;
			newkey = Tools.GetEntityPK("GI01");
			gridView2.SetRowCellValue(e.RowHandle, "GI002", GetCurTypeStr(curIndex));
			gridView2.SetRowCellValue(e.RowHandle, "GI001", newkey);
			gridView2.SetRowCellValue(e.RowHandle, "STATUS", "1");
			gridView2.SetRowCellValue(e.RowHandle, "PRICE", 0.00);
			gridView2.SetRowCellValue(e.RowHandle, "SORTID", Convert.ToInt32(newkey));
		}
		/// <summary>
		/// 编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName.Equals("GI003"))       //项目名称
			{
				if (String.IsNullOrEmpty(e.Value.ToString()))
				{
					e.Valid = false;
					e.ErrorText = "项目名称不能为空!";
				}
				else
				{
					for (int i = 0; i < gridView2.RowCount - 1; i++)
					{
						if (i == (sender as ColumnView).FocusedRowHandle) continue;
						if (gridView2.GetRowCellValue(i, "GI003") == null) continue;

						//如果名字相同,则校验不通过!                        
						if (String.Equals(gridView2.GetRowCellValue(i, "GI003").ToString(), e.Value.ToString()))
						{
							e.Valid = false;
							e.ErrorText = "名称已经存在!";
							break;
						}
					}
				}
			}
			else if (colName.Equals("PRICE"))   //单价
			{
				if (Decimal.Parse(e.Value.ToString()) < 0)
				{
					e.Valid = false;
					e.ErrorText = "单价不能小于0!";
				}
			}
		}
		/// <summary>
		/// 行验证
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GI003") == null)
			{
				e.Valid = false;
				(sender as ColumnView).SetColumnError(gridView2.Columns["GI003"], "名称不能为空!");
			}
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (gridView2.FocusedRowHandle >= 0)
			{
				if (XtraMessageBox.Show("确认要删除当前的记录吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}

			}
			gridView2.SetFocusedRowCellValue("STATUS", "0");
			gridView2.UpdateCurrentRow();
		}
		/// <summary>
		/// 上移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int row = gridView2.FocusedRowHandle;
			if (row <= 0) return;

			int prior_sortId = int.Parse(gridView2.GetRowCellValue(row - 1, "SORTID").ToString());
			int cur_sortId = int.Parse(gridView2.GetRowCellValue(row, "SORTID").ToString());

			gridView2.SetRowCellValue(row, "SORTID", prior_sortId);
			gridView2.SetRowCellValue(row - 1, "SORTID", cur_sortId);
		}
		/// <summary>
		/// 下移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int row = gridView2.FocusedRowHandle;
			if ((row >= gridView2.RowCount - 2) || row < 0) return;

			int next_sortId = int.Parse(gridView2.GetRowCellValue(row + 1, "SORTID").ToString());
			int cur_sortId = int.Parse(gridView2.GetRowCellValue(row, "SORTID").ToString());

			gridView2.SetRowCellValue(row, "SORTID", next_sortId);
			gridView2.SetRowCellValue(row + 1, "SORTID", cur_sortId);
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			gridView2.BeginUpdate();
			sp_ds.Gi01.Rows.Clear();
			op_gi002.Value = GetCurTypeStr(curIndex);
			sp_ds.Fill_Gi01();
			gridView2.EndUpdate();
		}
		/// <summary>
		/// 单元格修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			if (e.Column.FieldName == "GI003")
			{
				if (e.Value != System.DBNull.Value)
				{
					gridView2.SetFocusedRowCellValue("GI088", Tools.GetPYString(e.Value.ToString().Trim()));
				}
				else
				{
					gridView2.SetFocusedRowCellValue("GI088", System.DBNull.Value);
				}
			}
		}

		private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Save();
		}
		/// <summary>
		/// 查找
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (gridView2.IsFindPanelVisible)
				gridView2.HideFindPanel();
			else
				gridView2.ShowFindPanel();
		}

		private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			foreach (DataRow dr in sp_ds.Gi01.Rows)
			{
				if (!string.IsNullOrEmpty(dr["GI003"].ToString()))
					dr["GI088"] = Tools.GetPYString(dr["GI003"].ToString());

			}
		}
		/// <summary>
		/// 导出excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.Title = "导出Excel";
			fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx";

			DialogResult dialogResult = fileDialog.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions();
				options.TextExportMode = TextExportMode.Text;//设置导出模式为文本 
				gridControl2.ExportToXlsx(fileDialog.FileName, options);				 
				XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
