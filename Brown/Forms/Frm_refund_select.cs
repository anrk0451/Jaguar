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
using Brown.BaseObject;
using Oracle.ManagedDataAccess.Client;
using Brown.Action;
using Brown.Misc;
using Brown.Domain;

namespace Brown.Forms
{
    public partial class Frm_refund_select : BaseDialog
    {
        DataTable dt_sales = new DataTable();
        OracleParameter op_sa010 = new OracleParameter("sa010", OracleDbType.Varchar2, 10);
        OracleParameter op_sa020 = new OracleParameter("sa020", OracleDbType.Varchar2, 3);
        string s_sa010 = string.Empty;
        string s_sa020 = string.Empty;
        OracleDataAdapter salesAdapter =
            new OracleDataAdapter("select * from v_refund_select where sa010 = :fa001 and sa020 like :sa020", SqlAssist.conn);

        public Frm_refund_select()
        {            
            InitializeComponent(); 
        }

        private void Frm_refund_select_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt_sales;
            s_sa010 = this.swapdata["SA010"].ToString();
            s_sa020 = this.swapdata["SA020"].ToString();
            op_sa010.Direction = ParameterDirection.Input;
            op_sa020.Direction = ParameterDirection.Input;

            op_sa010.Value = s_sa010;
            op_sa020.Value = s_sa020;

            salesAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_sa010, op_sa020 });
            salesAdapter.Fill(dt_sales);

            gridColumn4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridColumn4.SummaryItem.DisplayFormat = "合计 = {0:N2}";

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 验证 退费数量合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            decimal dec_refundFee = decimal.Zero;
            int rowHandle = gridView1.FocusedRowHandle;
            if(decimal.TryParse(e.Value.ToString(), out dec_refundFee))
            {
                if(dec_refundFee > Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle,"SA007")))
                {
                    e.Valid = false;
                    e.ErrorText = "退费金额不能大于原收费金额!";
                    return;
                }
            }

        }

        /// <summary>
        /// 退费办理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!gridView1.PostEditor()) return;
            if (!gridView1.UpdateCurrentRow()) return;

            List<string> itemIdList = new List<string>();
            List<decimal> numsList = new List<decimal>();
            List<decimal> priceList = new List<decimal>();
            List<string> itemTypeList = new List<string>();
 
            decimal dec_fin_sum = decimal.Zero;
            decimal dec_temp = decimal.Zero;
 
            for(int i =0; i< gridView1.RowCount; i++)
            {
                if (decimal.TryParse(gridView1.GetRowCellValue(i,"REFUNDFEE").ToString(), out dec_temp))
                {   if (dec_temp <= 0) continue;
                    itemIdList.Add(gridView1.GetRowCellValue(i, "SA004").ToString());
                    priceList.Add(Convert.ToDecimal(gridView1.GetRowCellValue(i, "REFUNDFEE")));
                    numsList.Add(-1);
                    itemTypeList.Add(gridView1.GetRowCellValue(i,"SA002").ToString());
                    dec_fin_sum +=  Convert.ToDecimal(gridView1.GetRowCellValue(i, "REFUNDFEE"));   
                }
            }
            if(numsList.Count <= 0)
            {
                XtraMessageBox.Show("还未选择退费的项目!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            string s_fa001 = Tools.GetEntityPK("FA01");
            string s_memo = te_memo.Text;

            try
            {
                int re = MiscAction.FinRefundSettle(s_fa001, itemIdList.ToArray(), itemTypeList.ToArray(), priceList.ToArray(), numsList.ToArray(), Envior.cur_userId, s_memo, s_sa010);

                if (re > 0)
                {
                    XtraMessageBox.Show("退费结算完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string s_fa190 = SqlAssist.ExecuteScalar("select fa190 from fa01 where fa001='" + s_sa010 + "'").ToString();
                    if( s_fa190.Substring(0,1) == "1")  //原收费记录  财政发票已开
                    {
                        if (FinInvoice.GetCurrentPh() > 0)
                        {
                            if (XtraMessageBox.Show("下一张财政发票号码:" + Envior.FIN_NEXT_BILL_NO + ",是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FinInvoice.Refund(s_fa001);
                            }
                        }                        
                    }
                     
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ee)
            {
                XtraMessageBox.Show(ee.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName.ToUpper() == "SA020")
            {
                if (e.Value.ToString() == "T")
                    e.DisplayText = "税票";
                else
                    e.DisplayText = "财政票";
            }
        }
    }
}