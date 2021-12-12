using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Jaguar.Action;
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

namespace Jaguar.BusinessObject
{
    public partial class BatchEBillPrint : BaseBusiness
    {
        private DataTable dt_fa01 = new DataTable("FA01");
        private OracleDataAdapter fa01Adapter = new OracleDataAdapter("select * from v_ebill_batch where trunc(fa200) = trunc(sysdate)", SqlAssist.conn);
        public BatchEBillPrint()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += AppAction.DrawGridLineNo;
        }

        private void BatchEBillPrint_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt_fa01;
            fa01Adapter.Fill(dt_fa01);
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.BeginUpdate();
            dt_fa01.Rows.Clear();
            fa01Adapter.Fill(dt_fa01);
            gridView1.EndUpdate();
        }
        /// <summary>
        /// 打印电子票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                string s_fa001 = gridView1.GetRowCellValue(rowHandle, "FA001").ToString();
                //if (XtraMessageBox.Show("现在打印财政电子票吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                FinInvoice2.CallBrowserPrint(s_fa001);
                //}
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
        /// 发送通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
            if(e.Column.FieldName.ToUpper() == "FA002")
			{
                if (e.Value.ToString() == "0")
                    e.DisplayText = "火化业务";
                else if (e.Value.ToString() == "1")
                    e.DisplayText = "临时性销售";
                else if (e.Value.ToString() == "2")
                    e.DisplayText = "寄存业务";
			}
		}
	}
}
