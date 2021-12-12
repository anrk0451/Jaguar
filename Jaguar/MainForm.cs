﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using Jaguar.BaseObject;
using Jaguar.Misc;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Jaguar.Forms;
using Jaguar.Action;
using DevExpress.XtraEditors;
using DevExpress.XtraTab.ViewInfo;
using Jaguar.DataSet;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using TaxCardX;

namespace Jaguar
{
	public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

		//打印服务进程
		Process printprocess = new Process();
	 
		/// <summary>
		/// 业务对象
		/// </summary>
		class Bo01
		{
			public string bo001 { get; set; }   //业务编号

			public string bo003 { get; set; }   //业务名称
			public string bo004 { get; set; }   //业务对象类型 w-窗口 x-xtratabpage对象
		}
		 
		public Dictionary<string, Object> swapdata { get; set; }                                          //交换数据对象

		//追踪已经打开的Tab页
		private Dictionary<string, Bo01> businessTab = new Dictionary<string, Bo01>();
		private Dictionary<string, XtraTabPage> openedTabPage = new Dictionary<string, XtraTabPage>();
		private DataTable dt_bo01 = new DataTable("BO01");											      //存放业务对象表
 
		public MainForm()
		{
			SplashScreenManager.ShowForm(typeof(SplashScreen1));
			Thread.Sleep(2000);
			SplashScreenManager.CloseForm();
			InitializeComponent();
 
			Envior.mform = this;

			swapdata = new Dictionary<string, object>();

			//启动打印服务进程
			printprocess.StartInfo.FileName = "pbnative.exe";
			printprocess.Start();

		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			dt_bo01.Dispose();

			//断开数据库
			SqlAssist.DisConnect();
			 
			//关闭关联的打印进程
			if (!printprocess.HasExited) printprocess.Kill();			 
		}


		private void MainForm_Load(object sender, EventArgs e)
		{
			OracleDataAdapter bo01Adapter = SqlAssist.getSingleTableAdapter("select * from bo01");
			bo01Adapter.Fill(dt_bo01);

			List<Bo01> bo01_rows = ModelHelper.TableToEntity<Bo01>(dt_bo01);
			businessTab = bo01_rows.ToDictionary(key => key.bo001, value => value);

			Frm_login f_login = new Frm_login();
			f_login.ShowDialog();

			if (f_login.DialogResult == DialogResult.OK)  //登录成功处理..........
			{
				bsi_userName.Caption = Envior.cur_userName;
				bs_version.Caption = AppInfo.AppVersion;
				 
				f_login.Dispose();

				//读取发票基础信息
				this.ReadInvoiceBaseInfo();

				//连接打印进程
				this.ConnectPrtServ();
				 
				//创建打印服务对象
				//Envior.prtserv = new n_prtserv(); 
				 
				//读取 财政发票 开票点编码
				Envior.FIN_BILL_SITE = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath).AppSettings.Settings["BILLSITE"].Value.ToString();

				//寄存选号方式
				Envior.REG_CHOOSE_MODE = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath).AppSettings.Settings["REG_CHOOSE_MODE"].Value.ToString();

				///连接金税卡
				if (ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath).AppSettings.Settings["TAX_CARD"].Value.ToString() == "1")
					OpenTaxGoldCard();


			}              
		}

		/// <summary>
		/// 连接打印服务
		/// </summary>
		private void ConnectPrtServ()
		{
			IntPtr hwnd = FindWindow(null, "prtserv");
			if (hwnd != IntPtr.Zero)
			{
				Envior.prtservHandle = hwnd;
				int prtConnId = int.Parse(SqlAssist.ExecuteScalar("select seq_prtserv.nextval from dual", null).ToString());

				////建立连接
				PrtServAction.Connect(prtConnId, hwnd.ToInt32(), this.Handle.ToInt32());
				Envior.prtConnId = prtConnId;

				////给打印服务窗口发消息 建立连接
				SendMessage(hwnd, 0x2710, 0, prtConnId);
			}
			else
			{
				XtraMessageBox.Show("没有找到打印服务进程,不能打印!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}


		/// <summary>
		/// 读取发票信息
		/// </summary>
		private void ReadInvoiceBaseInfo()
		{
			OracleDataReader reader = SqlAssist.ExecuteReader("select * from sp01 where sp001  < '0000000100' ");
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					if (reader["SP002"].ToString() == "FIN_REGION_CODE")            //财政发票-区划
						Envior.FIN_REGION_CODE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_VERSION")           //财政发票-接口版本
						Envior.FIN_VERSION = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_AGENCY_CODE")       //财政发票-单位编码
						Envior.FIN_AGENCY_CODE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_AGENCY_NAME")       //财政发票-单位名称
						Envior.FIN_AGENCY_NAME = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_URL")				  //财政发票-服务url
						Envior.FIN_URL = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_APPID")             //财政发票-appid
						Envior.FIN_APPID = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_APPKEY")            //财政发票-appkey
						Envior.FIN_APPKEY = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_BATCH_CODE")        //财政发票-票据代码(以前的注册号)
						Envior.FIN_BATCH_CODE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_CODE")              //财政发票-票据种类编码(以前的票据类型)
						Envior.FIN_CODE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "FIN_BILLNAME")          //财政发票-票据名称
						Envior.FIN_BILLNAME = reader["SP005"].ToString();
 
					else if (reader["SP002"].ToString() == "tax_addrtele")             //税票-销方地址电话
						Envior.TAX_ADDR_TELE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "tax_bankaccount")          //税票-销方银行账号
						Envior.TAX_BANK_ACCOUNT = reader["SP005"].ToString();				 
					else if (reader["SP002"].ToString() == "tax_invoicetype")          //税票-发票类型
						Envior.TAX_INVOICE_TYPE = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "tax_cert_pwd")             //税票-税务金税卡密码
						Envior.TAX_CERT_PWD = reader["SP005"].ToString();
					else if (reader["SP002"].ToString() == "tax_code_ver")             //税票-税务分类编码版本
						Envior.TAX_CODE_VER = reader["SP005"].ToString();

				}
			}
			reader.Dispose();
		}

		/// <summary>
		/// 打开税务金卡
		/// </summary>
		private void OpenTaxGoldCard()
		{
			TaxInvoice.goldTax = new GoldTaxClass();
			TaxInvoice.goldTax.CertPassWord = Envior.TAX_CERT_PWD;
			TaxInvoice.goldTax.OpenCard();
			if (TaxInvoice.goldTax.RetCode == 1011)
			{
				XtraMessageBox.Show("打开金税卡成功!", "提示");
				Envior.TAX_READY = true;
			}
			else
			{
				XtraMessageBox.Show("打开金税卡失败!" + TaxInvoice.goldTax.RetCode.ToString() + TaxInvoice.goldTax.RetMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Envior.TAX_READY = false;
			}
		}



		/// <summary>
		/// 打开业务对象(如果没有则创建)
		/// </summary>
		public void openBusinessObject(string bo001)
		{
			openBusinessObject(bo001, null);
		}

		/// <summary>
		/// 打开业务对象(如果没有则创建)
		/// </summary>
		public void openBusinessObject(string bo001, object parm)
		{
			if (openedTabPage.ContainsKey(bo001))
			{
				xtraTabControl1.SelectedTabPage = openedTabPage[bo001];
				if (parm != null)
				{
					foreach (Control control in openedTabPage[bo001].Controls)
					{
						if (control is BaseBusiness)
						{
							((BaseBusiness)control).swapdata["parm"] = parm;
							((BaseBusiness)control).Business_Init();
							return;
						}
					}
				}
			}
			else //如果尚未打开，则new
			{
				XtraTabPage newPage = new XtraTabPage();
				newPage.Text = businessTab[bo001].bo003;
				newPage.Tag = bo001;
				newPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;

				BaseBusiness bo = (BaseBusiness)Activator.CreateInstance(Type.GetType("Jaguar.BusinessObject." + bo001));

				Envior.mform = this;

				bo.Dock = DockStyle.Fill;
				bo.Parent = newPage;
				bo.swapdata.Add("parm", parm);

				newPage.Controls.Add(bo);

				xtraTabControl1.TabPages.Add(newPage);
				xtraTabControl1.SelectedTabPage = newPage;

				bo.Business_Init();

				////////登记已打开 Tabpage ////////
				openedTabPage.Add(bo001, newPage);

			}
		}

		/// <summary>
		/// 关闭标签页事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
		{
			ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;

			XtraTabPage curPage = (XtraTabPage)arg.Page;
			///////// 清除页面追踪 ////////
			openedTabPage.Remove(curPage.Tag.ToString());

			curPage.Dispose();
		}


		/// <summary>
		/// 数据项维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("数据项维护")) return;
			openBusinessObject("DataDict");
		}

		/// <summary>
		/// 升级文件上传
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("系统升级")) return;
			Frm_Upgrade frm_1 = new Frm_Upgrade();
			frm_1.ShowDialog();
			frm_1.Dispose();
		}

		/// <summary>
		/// 税务发票项目维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			openBusinessObject("TaxItem");
		}

		

		/// <summary>
		/// 财政发票项目维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			openBusinessObject("FinItem");
		}

		/// <summary>
		/// 寄存结构维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("寄存结构维护")) return;
			openBusinessObject("RegisterStru");
		}


		/// <summary>
		/// 商品服务定价维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("商品及定价维护")) return;
			openBusinessObject("ServiceCommodity");
		}

		/// <summary>
		/// 进灵登记
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
		{
            try
            {
				if (!AppAction.CheckRight("进灵登记")) return;
				Frm_fireCheckin frm_checkin = new Frm_fireCheckin();
				frm_checkin.swapdata["action"] = "add";

				Checkin_ds checkin_ds = new Checkin_ds();
				frm_checkin.swapdata["dataset"] = checkin_ds;

				frm_checkin.ShowDialog();
				frm_checkin.Dispose();
			}
			catch(Exception ee)
            {
				XtraMessageBox.Show(ee.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				LogUtils.Error(ee.Message);
            }
		}

		/// <summary>
		/// 登记信息浏览
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("登记信息浏览")) return;
			openBusinessObject("FireCheckinBrow");
		}

		private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
		{
            //Frm_Demo frm_1 = new Frm_Demo();
            //frm_1.ShowDialog();
            //frm_1.Dispose();
            //Frm_FinInvoice frm_1 = new Frm_FinInvoice();
            //frm_1.ShowDialog();
            //frm_1.Dispose();
            openBusinessObject("BatchEBillPrint");
        }

		/// <summary>
		/// 临时销售
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("临时性销售")) return;
			openBusinessObject("TempSales");
		}

		/// <summary>
		/// 税务基础信息维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			Frm_TaxBaseInfo frm_1 = new Frm_TaxBaseInfo();
			frm_1.ShowDialog();
			frm_1.Dispose();
		}

		private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			openBusinessObject("Operators");
		}

		/// <summary>
		/// 日收费查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("业务收费日查询")) return;
			openBusinessObject("FinanceDaySearch");
		}
 
		/// <summary>
		/// 保存财政发票基础信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			Frm_FinBaseInfo frm_1 = new Frm_FinBaseInfo();
			frm_1.ShowDialog();
			frm_1.Dispose();
		}

		private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			openBusinessObject("Roles");
		}

		/// <summary>
		/// 寄存办理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("寄存数据浏览")) return;
			openBusinessObject("Register_brow"); 
		}

		/// <summary>
		/// 出灵数据查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("出灵数据查询")) return;
			openBusinessObject("Report_Checkout");
		}

		private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("寄存室数据")) return;
			openBusinessObject("RegisterRoomData");
		}

		/// <summary>
		/// 迁出数据查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("寄存迁出查询")) return;
			openBusinessObject("Report_RegisterOut");
			
		}


		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_ChgPwd frm_modify_pwd = new Frm_ChgPwd();
			frm_modify_pwd.ShowDialog();
		}

		private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("类别统计")) return;
			openBusinessObject("Report_Class_stat");
		}

		/// <summary>
		/// 套餐维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("服务套餐维护")) return;
			openBusinessObject("Combo");
		}

		/// <summary>
		/// 全部单项统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("单项统计")) return;
			openBusinessObject("Report_Item_Stat");
		}

		private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("寄存量统计")) return;
			openBusinessObject("Report_regstat");
		}

		private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("收款员收款统计")) return;
			openBusinessObject("Report_CasherStat");
		}

		/// <summary>
		/// 收款作废查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("收款作废查询")) return;
			openBusinessObject("Report_FinRollBack");
		}

		private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("补打火化证明查询")) return;
			openBusinessObject("Report_FireCertLog");
		}

		/// <summary>
		/// 财政发票项目统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("财政发票项目统计")) return;
			openBusinessObject("Report_FinItemStat");
		}

		/// <summary>
		/// 工作站统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("工作站开票统计")) return;
			openBusinessObject("Report_workstation");
		}

		/// <summary>
		/// 权限分配
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
		{
			if(Envior.cur_userId != AppInfo.ROOTID)
			{
				XtraMessageBox.Show("权限不足!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			openBusinessObject("RightGrant");
		}

		private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("业务办理")) return;
			openBusinessObject("BusinessHandleBrow");
		}

		/// <summary>
		/// 进灵登记查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("进灵登记查询")) return;
			openBusinessObject("Report_Checkin");
		}

		private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("火化安排")) return;
			openBusinessObject("Report_FireArrange");
		}

		/// <summary>
		/// 欠费数据统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("欠费数据统计")) return;
			openBusinessObject("Report_RegDebtData");
		}

		/// <summary>
		/// 馆内现存遗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("现存遗体查询")) return;
			openBusinessObject("BusinessHandleBrow");
		}

		private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_login frm_login = new Frm_login();
			frm_login.ShowDialog();
			frm_login.Dispose();
			bsi_userName.Caption = Envior.cur_userName;
		}

		private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
		{
			//Tools.GetIpAddress();
		}

		/// <summary>
		/// 工作站信息维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("工作站信息维护")) return;
			openBusinessObject("WorkStationList");
		}
		/// <summary>
		/// 服务商品及定价(祭品销售)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!AppAction.CheckRight("服务商品及定价(祭品销售)	")) return;
			openBusinessObject("ServiceCommodity_Jp");
		}

		private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_AvoidOption frm_1 = new Frm_AvoidOption();
			frm_1.ShowDialog();
			frm_1.Dispose();
		}
		/// <summary>
		/// 减免预收查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("ReportPreCash");
		}
		/// <summary>
		/// 临时demo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_Demo frm_1 = new Frm_Demo();
			frm_1.ShowDialog();
			frm_1.Dispose();
		}

		/// <summary>
		/// 处理窗口消息
		/// </summary>
		/// <param name="m"></param>
		//protected override void DefWndProc(ref Message m)
		//{
		//	switch (m.Msg)
		//	{
		//		case 10001:
		//			int commandNum = m.WParam.ToInt32();
		//			string responseText = PrtServAction.GetResponseText(commandNum);
		//			XtraMessageBox.Show(responseText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		//			break;
		//		default:
		//			base.DefWndProc(ref m);///调用基类函数处理非自定义消息。
		//			break;
		//	}
		//}
	}
}