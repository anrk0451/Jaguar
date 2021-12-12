using Jaguar.Misc;
using Jaguar.Domain;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Windows.Forms;
using RestSharp;
using TaxCardX;
using System.Runtime.InteropServices;

namespace Jaguar.Action
{
	/// <summary>
	/// 税务发票处理类
	/// </summary>
	class TaxInvoice
	{
		public static GoldTaxClass goldTax { get; set; }
		 
		/// <summary>
		/// 返回税务下一张票号!
		/// </summary>
		/// <returns></returns>
		public static string GetTaxInvoiceNextNum()
		{
			if (!Envior.TAX_READY)
				return "0";
			else
			{
				goldTax.GetInfo();
				if (Convert.ToInt32(goldTax.InfoNumber) == 0)
				{
					goldTax.GetInfo();
					return goldTax.InfoNumber.ToString();
				}
				else
					return goldTax.InfoNumber.ToString();
			}
		}
		 

		/// <summary>
		/// 发票开具
		/// </summary>
		/// <returns></returns>
		public static int Invoice(string fa001,TaxClientInfo taxClient)
		{
			return 1;
			string s_tax_name = string.Empty;
			string s_nextNum = GetTaxInvoiceNextNum();
			XtraMessageBox.Show("下一张税务发票号:" + s_nextNum, "", MessageBoxButtons.OK, MessageBoxIcon.Information);


			OracleDataReader reader = SqlAssist.ExecuteReader("select * from v_sa01 where sa010 ='" + fa001 + "' and abs(sa007) > 0");
			int i_counter = 0;

			///1.设置发票整体信息
			goldTax.InvInfoInit();   //发票信息初始化
			goldTax.InfoKind = 2;    //发票类型 - 普通发票
			goldTax.InfoSellerBankAccount = Envior.TAX_BANK_ACCOUNT;      //销方开户行及账号
			goldTax.InfoSellerAddressPhone = Envior.TAX_ADDR_TELE;		  //销方地址电话
			goldTax.InfoInvoicer = Envior.cur_userName;                         //开票人
			goldTax.InfoCashier = Envior.TAX_CASHIER;                           //收款人
			goldTax.InfoChecker = Envior.TAX_CHECKER;                           //复核人
			 
			goldTax.InfoClientName = taxClient.InfoClientName;                  //客户名称
			goldTax.InfoClientTaxCode = taxClient.InfoClientTaxCode;            //购方税号
			goldTax.InfoClientBankAccount = taxClient.infoclientbankaccount;    //购方银行账号
			goldTax.InfoClientAddressPhone = taxClient.infoclientaddressphone;  //购方地址电话

			goldTax.InfoTaxRate = 17;											//税率
			goldTax.InfoBillNumber = fa001;										//销售单据编号

			goldTax.ClearInvList();
			while (reader.Read())
			{
				if (reader["SA020"].ToString() != "T") continue;   //不是税务项目 忽略

				goldTax.InvListInit();
				goldTax.ListGoodsName = MiscAction.GetItemTaxName(reader["SA004"].ToString());   ///税务发票名称
				goldTax.InfoTaxRate = Convert.ToSByte(reader["SA025"]);                          ///税率
				goldTax.ListNumber = Convert.ToDouble(reader["NUMS"]);                           ///数量
				goldTax.ListPrice = Convert.ToDouble(reader["PRICE"]);                           ///单价
				goldTax.ListPriceKind = 1;                                                       ///含税价标志，单价和金额的种类， 0 为不含税价，1 为含税价 
				goldTax.AddInvList();				 
				i_counter++;
			}

			if (i_counter >  AppInfo.TAXITEMCOUNT )
			{
				goldTax.InfoListName = "商品服务项目清单" + fa001;   //设置后才会打印清单
			}

			//开具发票
			goldTax.Invoice();

			string s_invoice_code = string.Empty;
			int i_invoice_num = 0;
			if (goldTax.RetCode == 4011)
			{
				s_invoice_code = goldTax.InfoTypeCode;
				i_invoice_num = goldTax.InfoNumber;

				//记录发票日志
				int result = InvoiceLog(fa001, Envior.TAX_INVOICE_TYPE, Envior.cur_userName, Envior.TAX_CASHIER, Envior.TAX_CHECKER,
					taxClient.InfoClientName, taxClient.InfoClientTaxCode, taxClient.infoclientbankaccount, taxClient.infoclientaddressphone,
					s_invoice_code, i_invoice_num);

				if (result > 0)
				{
					XtraMessageBox.Show("税务发票开具成功!\r\n" + "发票代码:" + s_invoice_code + "\r\n" + "发票号码:" + i_invoice_num, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					XtraMessageBox.Show("税务发票开具成功!但记录开票日志失败!\r\n" + "发票代码:" + s_invoice_code + "\r\n" + "发票号码:" + i_invoice_num, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				////////// 打印发票和清单 //////////
				if (XtraMessageBox.Show("现在打印【税务发票】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					PrintInvoice(s_invoice_code, i_invoice_num, 0);
				}
				if (i_counter > AppInfo.TAXITEMCOUNT && XtraMessageBox.Show("现在打印【发票清单】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					PrintInvoice(s_invoice_code, i_invoice_num, 1);
				}

				return 1; 
				 
			}
			else
			{
				MessageBox.Show("错误代码:" + goldTax.RetCode + "\n" + "错误信息:" +  goldTax.RetMsg, "开票失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogUtils.Error("税务发票开票错误:\n" + goldTax.RetCode + "\n" + "错误信息:" + goldTax.RetMsg);
				return -1;
			}
		}


		/// <summary>
		/// 打印发票
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static int PrintInvoice(string fa001, short dylx)
		{
			using(OracleDataReader reader = SqlAssist.ExecuteReader("select * from tax_log where settleId='" + fa001 + "'"))
			{
				if (reader.HasRows && reader.Read())
				{
					return PrintInvoice(reader["INVOICECODE"].ToString(), Convert.ToInt32(reader["INVOICENUM"]), dylx);
				}
				else
				{
					XtraMessageBox.Show("未找到税务发票开具日志!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}
			}			 
		}

		/// <summary>
		/// 打印发票
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static int PrintInvoice(string fpdm, int fphm, short dylx)
		{
			try
			{
				goldTax.InfoKind = 2;                                           //发票类型	
				goldTax.InfoTypeCode = fpdm;									//发票代码
				goldTax.InfoNumber = fphm;										//发票号

				goldTax.InfoShowPrtDlg = 1;                        //是否显示确认对话框
				goldTax.GoodsListFlag = dylx;                      //打印发票 |  清单
				goldTax.PrintInv();
				return 1;
			}
			catch (Exception ee)
			{
				XtraMessageBox.Show(ee.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				LogUtils.Error("打印税务发票错误:\n" + "发票代码:" + fpdm + " 发票号:" + fphm + "\n" + ee.ToString());
				return -1;
			}
		}



		/// <summary>
		/// 负数发票开具
		/// </summary>
		/// <returns></returns>
		public static int InvoiceRefund(string fa001, TaxClientInfo taxClient)
		{
			return 1;
		}


		 
		/// <summary>
		/// 发票作废
		/// </summary>
		/// <param name="fpdm"></param>
		/// <param name="fphm"></param>
		/// <returns></returns>
		public static int Remove(string fa001,string zfr)
		{
			return 1;
		}


		public static int GetInvoiceStock(  string qshm,  string fpdm,  int fpfs)
		{			  

			return 1;
		}

		/// <summary>
		/// 记录发票日志
		/// </summary>
		/// <returns></returns>
		public static int InvoiceLog(string fa001,string infoKind,string INFOINVOICER,string INFOCASHIER,string INFOCHECKER,string INFOCLIENTNAME,
			string INFOCLIENTTAXCODE,string INFOCLIENTBANKACCOUNT,string INFOCLIENTADDRESSPHONE,string INVOICECODE,long INVOICENUM)
		{	
			//结算流水号
			OracleParameter op_fa001 = new OracleParameter("ic_fa001", OracleDbType.Varchar2, 10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;

			//发票类别
			OracleParameter op_kind = new OracleParameter("ic_infoKind", OracleDbType.Varchar2, 3);
			op_kind.Direction = ParameterDirection.Input;
			op_kind.Value = infoKind;

			//开票人
			OracleParameter op_invoicer = new OracleParameter("ic_INFOINVOICER", OracleDbType.Varchar2, 20);
			op_invoicer.Direction = ParameterDirection.Input;
			op_invoicer.Value = INFOINVOICER;

			//收款人
			OracleParameter op_cashier = new OracleParameter("ic_INFOCASHIER", OracleDbType.Varchar2, 20);
			op_cashier.Direction = ParameterDirection.Input;
			op_cashier.Value = INFOCASHIER;

			//复核人
			OracleParameter op_checker = new OracleParameter("ic_INFOCHECKER", OracleDbType.Varchar2, 20);
			op_checker.Direction = ParameterDirection.Input;
			op_checker.Value = INFOCHECKER;

			//客户名称
			OracleParameter op_clientName = new OracleParameter("ic_INFOCLIENTNAME", OracleDbType.Varchar2, 80);
			op_clientName.Direction = ParameterDirection.Input;
			op_clientName.Value = INFOCLIENTNAME;

			//客户税号
			OracleParameter op_clientTaxCode = new OracleParameter("ic_INFOCLIENTTAXCODE", OracleDbType.Varchar2, 50);
			op_clientTaxCode.Direction = ParameterDirection.Input;
			op_clientTaxCode.Value = INFOCLIENTTAXCODE;

			//客户银行账号
			OracleParameter op_bankAccount = new OracleParameter("ic_INFOCLIENTBANKACCOUNT", OracleDbType.Varchar2, 80);
			op_bankAccount.Direction = ParameterDirection.Input;
			op_bankAccount.Value = INFOCLIENTBANKACCOUNT;

			//客户地址电话
			OracleParameter op_addrTele = new OracleParameter("ic_INFOCLIENTADDRESSPHONE", OracleDbType.Varchar2, 80);
			op_addrTele.Direction = ParameterDirection.Input;
			op_addrTele.Value = INFOCLIENTADDRESSPHONE;

			//发票代码
			OracleParameter op_invcode = new OracleParameter("ic_INVOICECODE", OracleDbType.Varchar2, 20);
			op_invcode.Direction = ParameterDirection.Input;
			op_invcode.Value = INVOICECODE;

			//发票号码
			OracleParameter op_invnum = new OracleParameter("in_INVOICENUM", OracleDbType.Int64);
			op_invnum.Direction = ParameterDirection.Input;
			op_invnum.Value = INVOICENUM;
			 
			return SqlAssist.ExecuteProcedure("pkg_business.prc_TaxInvoiceLog", new OracleParameter[]
			{op_fa001,op_kind,op_invoicer,op_cashier,op_checker,op_clientName,op_clientTaxCode,op_bankAccount,op_addrTele,op_invcode,
			 op_invnum});
		}

		/// <summary>
		/// 退费(红色发票) 目前不允许退部分数量 只能整体退
		/// </summary>
		/// <param name="yfpdm"></param>
		/// <param name="yfph"></param>
		/// <param name="salesIdList"></param>
		/// <returns></returns>
		public static int Refund(string fa001, TaxClientInfo taxClient,string ofa001,List<string> salesIdList)
		{
			return 1;
		}


		/// <summary>
		/// 发票作废(单边)
		/// </summary>
		/// <param name="fpdm"></param>
		/// <param name="fphm"></param>
		/// <returns></returns>
		public static int Remove(string invcode,string invnum,decimal hjje, string zfr)
		{
			return 1;
		}


	}
}
