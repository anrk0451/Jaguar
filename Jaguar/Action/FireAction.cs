﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaguar.Action
{
	/// <summary>
	/// 火化业务-办理
	/// </summary>
	class FireAction
	{
		/// <summary>
		/// 火化登记记录删除
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int RemoveFireCheckin(string ac001, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_removeFireCheckin", new OracleParameter[] { op_ac001, op_handler });
		}

		/// <summary>
		/// 补打火化证明日志
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="fc100"></param>
		/// <returns></returns>
		public static int FireCertLog(string ac001,string fc100)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_fc100", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = fc100;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireCertLog", new OracleParameter[] { op_ac001, op_handler });
		}

		/// <summary>
		/// 获取休息室列表
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetRestRoomList(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			return SqlAssist.ExecuteScalar("select pkg_business.fun_getRestRoomList(:ac001) from dual", new OracleParameter[] { op_ac001 }).ToString();
		}

		/// <summary>
		/// 返回逝者告别时间
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static Object GetGBTime(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			Object re = SqlAssist.ExecuteScalar("select ac018 from ac01 where ac001 = :ac001", new OracleParameter[] { op_ac001 });
			return re;
		}

		/// <summary>
		/// 返回火化时间
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static Object GetHHTime(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			Object re = SqlAssist.ExecuteScalar("select ac015 from ac01 where ac001 = :ac001", new OracleParameter[] { op_ac001 });
			return re;
		}

		/// <summary>
		/// 返回火化存放位置Id
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetFireStoreId(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			Object re = SqlAssist.ExecuteFunction("pkg_business.fun_getFireStoreInfo", new OracleParameter[] { op_ac001 });
			return re.ToString();
		}

		/// <summary>
		/// 判断火化业务是否结算 1-结算 0-未结算
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string FireIsSettled(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			Object re = SqlAssist.ExecuteFunction("pkg_business.fun_FireIsSettled", new OracleParameter[] { op_ac001 });
			return re.ToString();
		}

		/// <summary>
		/// 守灵厅办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="nums"></param>
		/// <param name="so005"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_01(string ac001, string si001, decimal nums, DateTime so005, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//守灵厅编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//占用天数
			OracleParameter op_nums = new OracleParameter("in_nums", OracleDbType.Int16);
			op_nums.Direction = ParameterDirection.Input;
			op_nums.Value = nums;

			//存放开始时间
			OracleParameter op_so005 = new OracleParameter("id_so005", OracleDbType.Date);
			op_so005.Direction = ParameterDirection.Input;
			op_so005.Value = so005;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness01",
				new OracleParameter[] { op_ac001, op_si001, op_nums, op_so005, op_handler });
		}

		/// <summary>
		/// 冷藏办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="nums"></param>
		/// <param name="so005"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_02(string ac001, string si001, decimal nums, DateTime so005, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//冷藏编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//占用天数
			OracleParameter op_nums = new OracleParameter("in_nums", OracleDbType.Int16);
			op_nums.Direction = ParameterDirection.Input;
			op_nums.Value = nums;

			//存放开始时间
			OracleParameter op_so005 = new OracleParameter("id_so005", OracleDbType.Date);
			op_so005.Direction = ParameterDirection.Input;
			op_so005.Value = so005;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness02",
				new OracleParameter[] { op_ac001, op_si001, op_nums, op_so005, op_handler });
		}

		/// <summary>
		/// 休息室办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_03(string ac001, string si001, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//休息室编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness03",
				new OracleParameter[] { op_ac001, op_si001, op_handler });
		}

		/// <summary>
		/// 告别办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="so005"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_04(string ac001, string si001, DateTime so005, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//告别厅编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//存放开始时间
			OracleParameter op_so005 = new OracleParameter("id_so005", OracleDbType.Date);
			op_so005.Direction = ParameterDirection.Input;
			op_so005.Value = so005;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness04",
				new OracleParameter[] { op_ac001, op_si001, op_so005, op_handler });
		}

		/// <summary>
		/// 灵车办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_07(string ac001, string si001, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//告别厅编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness07",
				new OracleParameter[] { op_ac001, op_si001, op_handler });
		}

		/// <summary>
		/// 火化办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="si001"></param>
		/// <param name="so005"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_06(string ac001, string si001, DateTime so005, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//火化编号
			OracleParameter op_si001 = new OracleParameter("ic_si001", OracleDbType.Varchar2, 10);
			op_si001.Direction = ParameterDirection.Input;
			op_si001.Value = si001;

			//火化时间
			OracleParameter op_so005 = new OracleParameter("id_so005", OracleDbType.Date);
			op_so005.Direction = ParameterDirection.Input;
			op_so005.Value = so005;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusiness06",
				new OracleParameter[] { op_ac001, op_si001, op_so005, op_handler });
		}

		/// <summary>
		/// 销售项目编辑
		/// </summary>
		/// <param name="sa001"></param>
		/// <param name="price"></param>
		/// <param name="nums"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSalesEdit(string sa001, decimal price, decimal nums, string handler)
		{
			//逝者编号
			OracleParameter op_sa001 = new OracleParameter("ic_sa001", OracleDbType.Varchar2, 10);
			op_sa001.Direction = ParameterDirection.Input;
			op_sa001.Value = sa001;

			//单价
			OracleParameter op_price = new OracleParameter("in_price", OracleDbType.Decimal);
			op_price.Direction = ParameterDirection.Input;
			op_price.Value = price;

			//数量
			OracleParameter op_nums = new OracleParameter("in_nums", OracleDbType.Decimal);
			op_nums.Direction = ParameterDirection.Input;
			op_nums.Value = nums;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusinessEdit",
				new OracleParameter[] { op_sa001, op_price, op_nums, op_handler });
		}

		public static int TempSalesSettle(string cuname,string settleId, string[] itemId_arry, string[] itemType_arry, decimal[] price_arry, decimal[] nums_arry,
			string handler ,string memo)
		{
			//交款人姓名
			OracleParameter op_cuname = new OracleParameter("ic_cuname", OracleDbType.Varchar2, 100);
			op_cuname.Direction = ParameterDirection.Input;
			op_cuname.Value = cuname;

			//结算流水号
			OracleParameter op_settleId = new OracleParameter("ic_settleId", OracleDbType.Varchar2);
			op_settleId.Direction = ParameterDirection.Input;
			op_settleId.Value = settleId;

			//销售项目编号数组
			OracleParameter op_itemId_arry = new OracleParameter("ic_itemId_arry", OracleDbType.Varchar2);
			op_itemId_arry.Direction = ParameterDirection.Input;
			op_itemId_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_itemId_arry.Value = itemId_arry;

			//销售项目类型数组
			OracleParameter op_itemType_arry = new OracleParameter("ic_itemType_arry", OracleDbType.Varchar2);
			op_itemType_arry.Direction = ParameterDirection.Input;
			op_itemType_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_itemType_arry.Value = itemType_arry;

			//销售项目单价数组
			OracleParameter op_price_arry = new OracleParameter("in_price_arry", OracleDbType.Decimal);
			op_price_arry.Direction = ParameterDirection.Input;
			op_price_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_price_arry.Value = price_arry;

			//销售项目数量数组
			OracleParameter op_nums_arry = new OracleParameter("in_nums_arry", OracleDbType.Decimal);
			op_nums_arry.Direction = ParameterDirection.Input;
			op_nums_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_nums_arry.Value = nums_arry;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;
 
			//备注
			OracleParameter op_memo = new OracleParameter("ic_memo", OracleDbType.Varchar2, 80);
			op_memo.Direction = ParameterDirection.Input;
			op_memo.Value = memo;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_TempSalesSettle",
				new OracleParameter[] { op_cuname,op_settleId, op_itemId_arry, op_itemType_arry, op_price_arry, op_nums_arry, op_handler,op_memo });
		}

		/// <summary>
		/// 火化业务-删除业务项目!!!
		/// </summary>
		/// <param name="sa001"></param>
		/// <returns></returns>
		public static int FireBusinessRemove(string sa001)
		{
			//销售记录编号
			OracleParameter op_sa001 = new OracleParameter("ic_sa001", OracleDbType.Varchar2, 10);
			op_sa001.Direction = ParameterDirection.Input;
			op_sa001.Value = sa001;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusinessRemove",
				new OracleParameter[] { op_sa001 });
		}

		/// <summary>
		/// 应用用户套餐
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="cb001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireApplyUserCombo(string ac001, string cb001, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//套餐编号
			OracleParameter op_cb001 = new OracleParameter("ic_cb001", OracleDbType.Varchar2, 10);
			op_cb001.Direction = ParameterDirection.Input;
			op_cb001.Value = cb001;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_ApplyUserCombo",
				new OracleParameter[] { op_ac001, op_cb001, op_handler });
		}

		/// <summary>
		/// 服务商品办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="itemId"></param>
		/// <param name="nums"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSales_Misc(string ac001, string itemId, decimal nums, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//编号
			OracleParameter op_itemId = new OracleParameter("ic_itemId", OracleDbType.Varchar2, 10);
			op_itemId.Direction = ParameterDirection.Input;
			op_itemId.Value = itemId;

			//数量
			OracleParameter op_nums = new OracleParameter("in_nums", OracleDbType.Int16);
			op_nums.Direction = ParameterDirection.Input;
			op_nums.Value = nums;

			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusinessMisc",
				new OracleParameter[] { op_ac001, op_itemId, op_nums, op_handler });
		}

		/// <summary>
		/// 火化业务结算
		/// </summary>
		/// <param name="settleId"></param>
		/// <param name="ac001"></param>
		/// <param name="sa001_arry"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireBusinessSettle(string settleId, string ac001, string cuname,string[] sa001_arry, decimal cash,string avoidConfirm,decimal accountFee,decimal precash1,
			                                 decimal precash2,string handler)
		{
			//结算流水号
			OracleParameter op_settleId = new OracleParameter("ic_settleId", OracleDbType.Varchar2, 10);
			op_settleId.Direction = ParameterDirection.Input;
			op_settleId.Value = settleId;
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter("ic_ac001", OracleDbType.Varchar2);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			//交款人姓名
			OracleParameter op_cuname = new OracleParameter("ic_cuname", OracleDbType.Varchar2);
			op_cuname.Direction = ParameterDirection.Input;
			op_cuname.Value = cuname;
 
			//销售记录编号数组
			OracleParameter op_sa001_arry = new OracleParameter("ic_sa001_arry", OracleDbType.Varchar2);
			op_sa001_arry.Direction = ParameterDirection.Input;
			op_sa001_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_sa001_arry.Value = sa001_arry;

			//使用押金金额
			OracleParameter op_cash = new OracleParameter("in_cash", OracleDbType.Decimal);
			op_cash.Direction = ParameterDirection.Input;
			op_cash.Value = cash;

			//减免确认
			OracleParameter op_confirm = new OracleParameter("ic_avoidConfirm", OracleDbType.Varchar2, 3);
			op_confirm.Direction = ParameterDirection.Input;
			op_confirm.Value = avoidConfirm;

			//入账金额
			OracleParameter op_accountFee= new OracleParameter("in_accountFee", OracleDbType.Decimal);
			op_accountFee.Direction = ParameterDirection.Input;
			op_accountFee.Value = accountFee;

			//减免预收款金额（火化部分）
			OracleParameter op_precash1 = new OracleParameter("in_precash1", OracleDbType.Decimal);
			op_precash1.Direction = ParameterDirection.Input;
			op_precash1.Value = precash1;

			//减免预收款金额（寄存部分）
			OracleParameter op_precash2= new OracleParameter("in_precash2", OracleDbType.Decimal);
			op_precash2.Direction = ParameterDirection.Input;
			op_precash2.Value = precash2;
			 
			//经办人
			OracleParameter op_handler = new OracleParameter("ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;
 
			return SqlAssist.ExecuteProcedure("pkg_business.prc_FireBusinessSettle",
				new OracleParameter[] { op_settleId, op_ac001, op_cuname, op_sa001_arry,op_cash,op_confirm, op_accountFee,op_precash1,op_precash2,op_handler});

		}

		/// <summary>
		/// 根据逝者编号获取逝者姓名
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetGuyNameById(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			return SqlAssist.ExecuteScalar("select ac003 from ac01 where ac001 =:ac001",new OracleParameter[] { op_ac001}).ToString();
		}
		/// <summary>
		/// 设置火化时间
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="ac015"></param>
		/// <returns></returns>
		public static int SetFireTime(string ac001,string ac015)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			//火化时间
			OracleParameter op_ac015 = new OracleParameter(":ac015", OracleDbType.Varchar2,50);
			op_ac015.Direction = ParameterDirection.Input;
			op_ac015.Value = ac015;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_SetFireTime",
				new OracleParameter[] { op_ac001,op_ac015});
		}
		/// <summary>
		/// 缴纳押金
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="cash"></param>
		/// <param name="payer"></param>
		/// <param name="billno"></param>
		/// <returns></returns>
		public static int PayCash(string ac001,decimal cash,string payer,string billno,string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			//押金金额
			OracleParameter op_cash = new OracleParameter(":cash", OracleDbType.Decimal);
			op_cash.Direction = ParameterDirection.Input;
			op_cash.Value = cash;
			//交款人
			OracleParameter op_payer = new OracleParameter(":payer", OracleDbType.Varchar2, 20);
			op_payer.Direction = ParameterDirection.Input;
			op_payer.Value = payer;
			//单据号
			OracleParameter op_billno = new OracleParameter(":billno", OracleDbType.Varchar2, 50);
			op_billno.Direction = ParameterDirection.Input;
			op_billno.Value = billno;
			//经办人
			OracleParameter op_handler = new OracleParameter(":handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_PayCash", new OracleParameter[] { op_ac001, op_cash,op_payer,op_billno,op_handler});
		}
		/// <summary>
		/// 返回逝者押金余额 
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static decimal GetCash(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			return Convert.ToDecimal(SqlAssist.ExecuteScalar("select pkg_report.fun_GetCash(:ac001) from dual", new OracleParameter[] { op_ac001 }));
		}
		/// <summary>
		/// 返回逝者减免预收款
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static decimal GetPreCash(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			return Convert.ToDecimal(SqlAssist.ExecuteScalar("select pkg_report.fun_GetPreCash(:ac001) from dual", new OracleParameter[] { op_ac001 }));
		}

		/// <summary>
		/// 返回逝者寄存减免预收款
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static decimal GetRegPreCashById(string ac001)
		{
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			return Convert.ToDecimal(SqlAssist.ExecuteScalar("select pkg_business.fun_GetRegPreCashById(:ac001) from dual", new OracleParameter[] { op_ac001 }));
		}




		/// <summary>
		/// 减免预存款入账
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="fa001"></param>
		/// <param name="fa002"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int PreCashAccount(string ac001,string fa001, string handler)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			//结算流水号
			OracleParameter op_fa001 = new OracleParameter(":fa001", OracleDbType.Varchar2,10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;
			 
		 
			//经办人
			OracleParameter op_handler = new OracleParameter(":handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_PreCashAccount", new OracleParameter[] { op_ac001, op_fa001, op_handler });
		}




		/// <summary>
		/// 应用减免选项
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="ac070"></param>
		/// <returns></returns>
		public static int ApplyAvoid(string ac001,string ac070)
		{
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter(":ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			 
			//减免类型
			OracleParameter op_ac070 = new OracleParameter(":ac070", OracleDbType.Varchar2, 10);
			op_ac070.Direction = ParameterDirection.Input;
			op_ac070.Value = ac070;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_ApplyAvoid", new OracleParameter[] { op_ac001,op_ac070});
		}
		/// <summary>
		/// 减免确认
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int AvoidConfirm(string ac001,string handler)
        {
			//逝者编号
			OracleParameter op_ac001 = new OracleParameter(":ic_ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;

			//经办人
			OracleParameter op_handler = new OracleParameter(":ic_handler", OracleDbType.Varchar2, 10);
			op_handler.Direction = ParameterDirection.Input;
			op_handler.Value = handler;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_AvoidConfirm", new OracleParameter[] { op_ac001, op_handler });
		}

	}
}
