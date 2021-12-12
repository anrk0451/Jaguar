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
using Jaguar.DataSet;
using Jaguar.Action;
using Jaguar.Misc;
using Jaguar.Domain;

namespace Jaguar.Forms
{
    public partial class Frm_FireSettle : BaseDialog
    {
        FireBusiness_ds business_ds = null;
        string AC001 = string.Empty;
        List<int> rowList;
        DataTable dt_source;

        decimal dec_cash, dec_ysje, dec_yj,dec_precash,dec_reg_precash;


        public Frm_FireSettle()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += AppAction.DrawGridLineNo;
        }

        private void Frm_FireSettle_Load(object sender, EventArgs e)
        {
            AC001 = this.swapdata["AC001"].ToString();
            business_ds = this.swapdata["dataset"] as FireBusiness_ds;
            rowList = this.swapdata["rowList"] as List<int>;


            ///拷贝要结算的记录!!!
            dt_source = business_ds.Sa01.Clone();
            foreach (int i in rowList)
            {
                dt_source.Rows.Add(business_ds.Sa01.Rows[i].ItemArray);
            }
            gridControl1.DataSource = dt_source;

            /////检索 押金 //////
            dec_yj = FireAction.GetCash(AC001);
            te_yj.EditValue = dec_yj;

            Calc_Je();
            

            ////减免确认 ////////////////////////////////
            int row = gridView1.LocateByValue("SA002", "06");
            if (row >= 0)
            {
                string s_ac070 = SqlAssist.ExecuteScalar("select ac070 from ac01 where ac001='" + AC001 + "'").ToString();
                if(s_ac070 != AppInfo.AVOID_TYPE_NO)
                {
                    checkEdit1.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 计算应交金额
        /// </summary>
        private void Calc_Je()
        {
            if (checkEdit1.Checked)  //减免确认
            {
                dec_precash = 0;
                dec_reg_precash = 0;
                dec_ysje = Convert.ToDecimal(gridView1.Columns["ACTUALFEE"].SummaryItem.SummaryValue);                
            }
            else
            {
                if (checkEdit2.Checked)
                    dec_reg_precash = Convert.ToDecimal(te_reg_precash.EditValue);
                else
                    dec_reg_precash = 0;

                dec_ysje = Convert.ToDecimal(gridView1.Columns["ACTUALFEE"].SummaryItem.SummaryValue);
                dec_precash = Convert.ToDecimal(gridView1.Columns["AVOIDFEE"].SummaryItem.SummaryValue) + dec_reg_precash;
            }            
             
            dec_cash = dec_yj >= dec_ysje ? 0 : dec_ysje - dec_yj + dec_precash;

            te_precash.EditValue = dec_precash - dec_reg_precash;
            te_ysje.EditValue = dec_ysje;
            te_cash.EditValue = dec_cash;
        }
        /// <summary>
        /// 寄存减免预收金额改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void te_reg_precash_EditValueChanged(object sender, EventArgs e)
		{
            this.Calc_Je();
		}

		/// <summary>
		/// 是否办理寄存 重新计算减免预收额度
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkEdit2_CheckedChanged(object sender, EventArgs e)
		{
            
			if (checkEdit2.Checked)
			{
                te_reg_precash.EditValue = FireAction.GetRegPreCashById(AC001);
                te_reg_precash.Enabled = true;
            }
			else
			{
                te_reg_precash.EditValue = 0;
                te_reg_precash.Enabled = false;
            }
            this.Calc_Je();
        }

		/// <summary>
		/// 减免确认
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkEdit1.Checked)
			{
                checkEdit2.Enabled = false;
                checkEdit2.Checked = false;
                te_reg_precash.EditValue = 0;
                te_reg_precash.Enabled = false;
                
            }
			else
			{
                checkEdit2.Enabled = true;             
            }               

            this.Calc_Je();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            decimal dec_fin = new decimal(0);
            decimal dec_tax = new decimal(0);
            decimal dec_avoid = new decimal(0);
            decimal dec_cash = Convert.ToDecimal(te_yj.Text);
            decimal dec_account = new decimal(0);
            string s_tip = string.Empty;

            foreach(DataRow dr in dt_source.Rows)
            {
                if (dr["SA020"].ToString() == "F")
                    dec_fin += Convert.ToDecimal(dr["ACTUALFEE"]);
                else if (dr["SA020"].ToString() == "T")
                    dec_tax += Convert.ToDecimal(dr["ACTUALFEE"]);

                dec_avoid += Convert.ToDecimal(dr["AVOIDFEE"]);
                dec_account += Convert.ToDecimal(dr["ACTUALFEE"]);
            }
            dec_reg_precash = Convert.ToDecimal(te_reg_precash.EditValue);


            if (dec_fin > 0 && dec_tax > 0)
                s_tip = "本次结算共需要一张财政发票和一张税务发票,是否继续?";
            else if (dec_fin > 0)
                s_tip = "本次结算共需要一张财政发票,是否继续?";
            else if (dec_tax > 0)
                s_tip = "本次结算共需要一张税务发票,是否继续?";
            else if (dec_tax + dec_fin == 0)
                s_tip = "本次结算实际应收金额为0,是否继续?";
            else
                return;

            if (XtraMessageBox.Show(s_tip, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            string s_fa001 = Tools.GetEntityPK("FA01");
            string s_cuname = FireAction.GetGuyNameById(AC001);
            List<string> sa001_list = new List<string>();
            foreach (DataRow r in dt_source.Rows)
            {
                sa001_list.Add(r["SA001"].ToString());
            }

            int result = FireAction.FireBusinessSettle(s_fa001,
                                                       AC001,
                                                       s_cuname,
                                                       sa001_list.ToArray(),
                                                       dec_cash,
                                                       checkEdit1.Checked? "1":"0",
                                                       dec_account,
                                                       dec_precash - dec_reg_precash,
                                                       dec_reg_precash,
                                                       Envior.cur_userId 
            );

            if (result > 0)
            {
                XtraMessageBox.Show("结算完成!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                b_ok.Enabled = false;
                int fire_row = gridView1.LocateByValue("SA002", "06");
                //如果有火化,打印火化证明
                if (fire_row >= 0)
                {   //打印火化证明
                    if (XtraMessageBox.Show("现在打印火化证明?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        PrtServAction.Print_HHZM(AC001,0);
                }

                XtraMessageBox.Show(dec_fin + dec_tax > 0 ? "结算成功!现在开始开具发票!" :"结算成功!" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////开财政票!
                if (dec_fin > 0)
                {                     
                    if(FinInvoice2.Invoice(s_fa001) > 0)
					{
                        if(XtraMessageBox.Show("现在打印财政电子票吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
						{
                            FinInvoice2.CallBrowserPrint(s_fa001);
                        }
					}
                }

                //// 开税票
                if (dec_tax > 0)
                {
                    if(XtraMessageBox.Show("现在打印税务项目清单?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PrtServAction.Print_Sales_List(s_fa001, "T", Envior.mform.Handle.ToInt32());
                    }
                    //if (Envior.TAX_READY)
                    //{
                    //    //获取税务客户信息
                    //    string s_ac003 = SqlAssist.ExecuteScalar("select ac003 from ac01 where ac001='" + AC001 + "'").ToString();
                    //    Frm_TaxClientInfo frm_taxClient = new Frm_TaxClientInfo(s_ac003);
                    //    if (frm_taxClient.ShowDialog() != DialogResult.OK) return;
                    //    TaxClientInfo clientInfo = frm_taxClient.swapdata["taxclientinfo"] as TaxClientInfo;

                    //    string s_next_inv = TaxInvoice.GetTaxInvoiceNextNum();
                    //    if (!Envior.TAX_READY && s_next_inv != "0")
                    //    {
                    //        if (XtraMessageBox.Show("下一张税票号:" + s_next_inv + ",是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //        {
                    //            TaxInvoice.Invoice(s_fa001, clientInfo);
                    //        }
                    //    }
                    //}
                    //else 
                    //    XtraMessageBox.Show("金税卡未打开!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

                //如果有减免预收款 
                if(dec_precash > 0)
				{
                    if(XtraMessageBox.Show("现在打印减免预收款【收据】吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        PrtServAction.Print_PreCashBill(AC001, "%", Envior.cur_userId, Envior.mform.Handle.ToInt32());
				}
                 
                this.DialogResult = DialogResult.OK;
                this.Close();                
            }
        }
    }
}