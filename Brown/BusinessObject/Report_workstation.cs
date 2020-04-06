using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Brown.BaseObject;
using Brown.Action;
using Oracle.ManagedDataAccess.Client;
using Brown.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;

namespace Brown.BusinessObject
{
    public partial class Report_workstation : BaseBusiness
    {
        private DataTable dt_wsStat = new DataTable();
        private OracleDataAdapter statAdapter = new OracleDataAdapter("select * from rep_workStation order by ws001", SqlAssist.conn);

        private DataTable dt_finInvoice = new DataTable();
        private OracleDataAdapter finAdapter = new OracleDataAdapter("select * from v_financeDay_invoices where billType = 'F' and fa100 = :fa100 and (to_char(fa200,'yyyy-mm-dd') between :begin and :end) ", SqlAssist.conn);

        private DataTable dt_taxInvoice = new DataTable();
        private OracleDataAdapter taxAdapter = new OracleDataAdapter("select * from v_financeDay_invoices where billType = 'T' and fa100 = :fa100 and (to_char(fa200,'yyyy-mm-dd') between :begin and :end) ", SqlAssist.conn);


        private OracleParameter op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
        private OracleParameter op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
        private OracleParameter op_ws001 = new OracleParameter("ws001", OracleDbType.Varchar2, 10);
         
        private string s_begin = string.Empty;
        private string s_end = string.Empty;
        private string s_ws001 = string.Empty;
         
        public Report_workstation()
        {
            InitializeComponent();
        }

        private void Report_workstation_Load(object sender, EventArgs e)
        {
            op_end.Direction = ParameterDirection.Input;
            op_begin.Direction = ParameterDirection.Input;
            op_ws001.Direction = ParameterDirection.Input;

            statAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_ws001, op_begin, op_end });           
            gridControl_center.DataSource = dt_wsStat;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.RefreshData();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            if (MiscAction.WorkStationStat(s_ws001,s_begin, s_end) > 0)
            {
                this.Cursor = Cursors.WaitCursor;

                dt_wsStat.Rows.Clear();
                statAdapter.Fill(dt_wsStat);

                //财政笔数
                gridColumn3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn3.SummaryItem.DisplayFormat = "{0:N0}";
                //财政金额
                gridColumn4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn4.SummaryItem.DisplayFormat = "{0:N2}";
                //税务笔数
                gridColumn5.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn5.SummaryItem.DisplayFormat = "{0:N0}";
                //税务金额
                gridColumn6.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn6.SummaryItem.DisplayFormat = "{0:N2}";

                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_wsStat frm_1 = new Frm_wsStat();
            if (frm_1.ShowDialog() == DialogResult.OK)
            {
                if (frm_1.swapdata["dbegin"] == null || frm_1.swapdata["dbegin"] is System.DBNull)
                {
                    s_begin = "1900-01-01";
                }
                else
                {
                    s_begin = Convert.ToDateTime(frm_1.swapdata["dbegin"]).ToString("yyyy-MM-dd");
                }

                if (frm_1.swapdata["dend"] == null || frm_1.swapdata["dend"] is System.DBNull)
                {
                    s_end = "9999-12-31";
                }
                else
                {
                    s_end = Convert.ToDateTime(frm_1.swapdata["dend"]).ToString("yyyy-MM-dd");
                }

                if (frm_1.swapdata["ws001"] == null)
                    s_ws001 = "%";
                else
                    s_ws001 = frm_1.swapdata["ws001"].ToString();

                op_begin.Value = s_begin;
                op_end.Value = s_end;
                op_ws001.Value = s_ws001;

                this.RefreshData();
            }
            frm_1.Dispose();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridControl grid = gridControl_center;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx";

            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions();
                options.TextExportMode = TextExportMode.Text;//设置导出模式为文本
                grid.ExportToXlsx(fileDialog.FileName, options);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
