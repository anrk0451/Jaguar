using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Forms;
using Jaguar.Misc;
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

namespace Jaguar.BusinessObject
{
    public partial class ReportPreCash : BaseBusiness
    {
        private DataTable dt_precash = new DataTable();
        private OracleDataAdapter precashAdapter = new OracleDataAdapter("select * from v_report_precash where to_char(ac200,'yyyy-mm-dd') between :begin and :end", SqlAssist.conn);
        
        private DataTable dt_detail = new DataTable("DETAIL");
        private OracleDataAdapter deAdapter =
            new OracleDataAdapter("select * from ac12 where ac021 = :ac021 and ac034 > 0 ", SqlAssist.conn);

        private OracleParameter op_begin = null;
        private OracleParameter op_end = null;
        private OracleParameter op_ac021 = null;
        public ReportPreCash()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += AppAction.DrawGridLineNo;
        }

        private void ReportPreCash_Load(object sender, EventArgs e)
        {
            op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
            op_begin.Direction = ParameterDirection.Input;
            op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
            op_end.Direction = ParameterDirection.Input;
            op_ac021 = new OracleParameter("ac021", OracleDbType.Varchar2, 10);
            op_ac021.Direction = ParameterDirection.Input;

            precashAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end });
            deAdapter.SelectCommand.Parameters.Add(op_ac021);

            gridControl1.DataSource = dt_precash;
            gridControl2.DataSource = dt_detail;

            op_begin.Value = MiscAction.GetServerTime().ToString("yyyy-MM-dd");
            op_end.Value = MiscAction.GetServerTime().ToString("yyyy-MM-dd");

            precashAdapter.Fill(dt_precash);

            gridColumn7.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridColumn7.SummaryItem.DisplayFormat = "合计 = {0:N2}";

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName.ToUpper() == "AC100")  //操作员
            {
                e.DisplayText = MiscAction.Mapper_operator(e.Value.ToString());
            }
            else if(e.Column.FieldName.ToUpper() == "FA002")
            {
                if (e.Value.ToString() == "0")
                    e.DisplayText = "火化业务";
                else if (e.Value.ToString() == "2")
                    e.DisplayText = "寄存业务";
            }
            else if(e.Column.FieldName.ToUpper() == "STATUS")
            {
                if (e.Value.ToString() == "1")
                    e.DisplayText = "收取";
                else if (e.Value.ToString() == "2")
                    e.DisplayText = "入账";
                else if (e.Value.ToString() == "3")
                    e.DisplayText = "退还";
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            Frm_duration frm_1 = new Frm_duration();
            frm_1.swapdata["MODE"] = "1";

            if (frm_1.ShowDialog() == DialogResult.OK)
            {
                string s_begin = string.Empty;
                string s_end = string.Empty;

                if (frm_1.swapdata["begin"] == null)
                {
                    s_begin = "1900-01-01";
                }
                else
                {
                    s_begin = Convert.ToDateTime(frm_1.swapdata["begin"]).ToString("yyyy-MM-dd");
                }

                if (frm_1.swapdata["end"] == null)
                {
                    s_end = "9999-12-31";
                }
                else
                {
                    s_end = Convert.ToDateTime(frm_1.swapdata["end"]).ToString("yyyy-MM-dd");
                }
                 
                op_begin.Value = s_begin;
                op_end.Value = s_end;

                this.Cursor = Cursors.WaitCursor; 
                gridView1.BeginUpdate();
                dt_precash.Rows.Clear();
                precashAdapter.Fill(dt_precash);                 
                gridView1.EndUpdate();
 
                this.Cursor = Cursors.Arrow;
            }
            frm_1.Dispose();
        }
        /// <summary>
        /// 检索明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                string s_ac021 = gridView1.GetRowCellValue(rowHandle, "AC021").ToString();
                op_ac021.Value = s_ac021;
                gridView2.BeginUpdate();
                dt_detail.Rows.Clear();
                deAdapter.Fill(dt_detail);
                gridView2.EndUpdate();
            }
        }

		private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
            if(e.Column.FieldName.ToUpper() == "AC033")
			{
                if (e.Value.ToString() == "01" || e.Value.ToString() == "02")
                    e.DisplayText = "遗体存放";
                else if (e.Value.ToString() == "06")
                    e.DisplayText = "火化";
                else if (e.Value.ToString() == "07")
                    e.DisplayText = "遗体接运";
                else if (e.Value.ToString() == "08")
                    e.DisplayText = "骨灰寄存";
			}
		}
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
		}
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            this.RefreshData();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx";

            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions();
                options.TextExportMode = TextExportMode.Text;//设置导出模式为文本
                gridControl1.ExportToXlsx(fileDialog.FileName, options);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 减免确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
                string s_status = gridView1.GetRowCellValue(rowHandle, "STATUS").ToString();
                if(s_status != "1")
				{
                    XtraMessageBox.Show("该预收款已经被处理!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
				}
                string s_ac001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
                Frm_avoidConfirm frm_1 = new Frm_avoidConfirm();
                frm_1.swapdata["ac001"] = s_ac001;
                if (frm_1.ShowDialog() == DialogResult.OK)
                    this.RefreshData();
                frm_1.Dispose();
            }            
		}
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
		{
            this.Cursor = Cursors.WaitCursor;
            gridView1.BeginUpdate();
            dt_precash.Rows.Clear();
            precashAdapter.Fill(dt_precash);
            gridView1.EndUpdate();

            this.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// 入账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                string s_status = gridView1.GetRowCellValue(rowHandle, "STATUS").ToString();
                if (s_status != "1")
                {
                    XtraMessageBox.Show("该预收款已经被处理!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (XtraMessageBox.Show("确认要做入账处理吗? 预收的款项将作为业务收入并开具发票!","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
                string s_ac021 = gridView1.GetRowCellValue(rowHandle, "AC021").ToString();               
                string s_fa001 = Tools.GetEntityPK("FA01");
                if(FireAction.PreCashAccount(s_ac021, s_fa001,Envior.cur_userId) > 0)
				{
                    XtraMessageBox.Show("入账办理成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    XtraMessageBox.Show("现在准备开始开具发票!!!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (FinInvoice2.Invoice(s_fa001) > 0)
                    {
                        if (XtraMessageBox.Show("现在打印财政电子票吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            FinInvoice2.CallBrowserPrint(s_fa001);
                        }
                    }
                    this.RefreshData();
                }
                
            }
        }
        /// <summary>
        /// 补打预收收据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
                string s_ac001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
                if (XtraMessageBox.Show("确认要打印【收据】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    PrtServAction.Print_PreCashBill(s_ac001, "%", Envior.cur_userId, Envior.mform.Handle.ToInt32());
			}
		}
	}
}
