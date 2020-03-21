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
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Brown.Misc;
using Brown.Action;

namespace Brown.BusinessObject
{
    public partial class BusinessHandleBrow : BaseBusiness
    {
        private DataTable dt_ac01 = new DataTable();
        private OracleDataAdapter ac01Adaapter = new OracleDataAdapter("select * from  v_having", SqlAssist.conn);

        public BusinessHandleBrow()
        {
            InitializeComponent();
        }

        private async void BusinessHandleBrow_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = dt_ac01;
            //如果在另一个线程中修改UI ,会报错!!! 所以datasource只能在 检索数据线程 结束后绑定

            this.Cursor = Cursors.WaitCursor;
            gridView1.BeginUpdate();
            await RefreshData();
            gridView1.EndUpdate();
            this.Cursor = Cursors.Arrow;

            gridControl1.DataSource = dt_ac01;
        }
        private async Task RefreshData()
        {
            await Task.Run(() =>
            {
                dt_ac01.Rows.Clear();
                ac01Adaapter.Fill(dt_ac01);
            }
                );      
        }

        /// <summary>
        /// 绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        /// 业务办理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    Business(gridView1.FocusedRowHandle);
                }
            }
        }

        /// <summary>
        /// 业务办理
        /// </summary>
        /// <param name="rowHandle"></param>
        private void Business(int rowHandle)
        {
            if (!AppAction.CheckRight("业务办理")) return;
            string s_ac001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
            (Envior.mform as MainForm).openBusinessObject("FireBusiness", s_ac001);
        }

        /// <summary>
        /// 业务办理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle < 0) return;

            this.Business(rowHandle);
        }

        private async void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gridView1.BeginUpdate();
            gridControl1.DataSource = null;
            await RefreshData();
            gridControl1.DataSource = dt_ac01;
            gridView1.EndUpdate();
            this.Cursor = Cursors.Arrow;
        }
 
         
    }
}
