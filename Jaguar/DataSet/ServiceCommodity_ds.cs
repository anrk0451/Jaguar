﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaguar.DataSet
{
	/// <summary>
	/// 服务商品定价 - 数据集
	/// </summary>
	class ServiceCommodity_ds : System.Data.DataSet
	{
		public DataTable Si01 { get; }
		public DataTable Gi01 { get; }
		public DataTable Ii01 { get; }


		public OracleDataAdapter si01Adapter { get; }
		public OracleDataAdapter gi01Adapter { get; }
		public OracleDataAdapter ii01Adapter { get; }


		OracleCommandBuilder sibuilder = null;
		OracleCommandBuilder gibuilder = null;

		public ServiceCommodity_ds()
		{
			DataColumn col_si001 = new DataColumn("SI001", typeof(string));   // 服务编号
			DataColumn col_si002 = new DataColumn("SI002", typeof(string));   // 服务类别
			DataColumn col_si003 = new DataColumn("SI003", typeof(string));   // 服务项目名称
			DataColumn col_price = new DataColumn("PRICE", typeof(decimal));  // 单价
			DataColumn col_si005 = new DataColumn("SI005", typeof(string));   // 占用标志
			DataColumn col_si088 = new DataColumn("SI088", typeof(string));   // 助记符
			DataColumn col_si077 = new DataColumn("SI077", typeof(string));   // 发票类型
			DataColumn col_si099 = new DataColumn("SI099", typeof(string));   // 发票编码
			DataColumn col_si066 = new DataColumn("SI066", typeof(string));   // 规格型号
			DataColumn col_si055 = new DataColumn("SI055", typeof(string));   // 单位
			DataColumn col_sortId = new DataColumn("SORTID", typeof(int));    // 排序号
			DataColumn col_status = new DataColumn("STATUS", typeof(string)); // 状态

			Si01 = new DataTable("Si01");
			Si01.Columns.AddRange(new DataColumn[]
				{col_si001,col_si002,col_si003,col_price,col_si005,col_si088,col_si077,col_sortId,col_si099,col_status,col_si066,col_si055});
			Si01.PrimaryKey = new DataColumn[] { col_si001 };                //设置主键

			this.Tables.Add(Si01);

			si01Adapter = new OracleDataAdapter("select * from si01 where si002 = :si002  order by si002,sortId", SqlAssist.conn);
			si01Adapter.Requery = true;

			sibuilder = new OracleCommandBuilder(si01Adapter);

			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			DataColumn col_gi001 = new DataColumn("GI001", typeof(string));   // 商品编号
			DataColumn col_gi002 = new DataColumn("GI002", typeof(string));   // 商品类别
			DataColumn col_gi003 = new DataColumn("GI003", typeof(string));   // 商品名称
			DataColumn col_price2 = new DataColumn("PRICE", typeof(decimal)); // 商品单价      
			DataColumn col_gi088 = new DataColumn("GI088", typeof(string));   // 助记符
			DataColumn col_gi077 = new DataColumn("GI077", typeof(string));   // 发票类型
			DataColumn col_gi099 = new DataColumn("GI099", typeof(string));   // 财政发票编码
			DataColumn col_sortId2 = new DataColumn("SORTID", typeof(int));   // 排序号
			DataColumn col_gi066 = new DataColumn("GI066", typeof(string));   // 规格型号
			DataColumn col_gi055 = new DataColumn("GI055", typeof(string));   // 单位

			DataColumn col_status_2 = new DataColumn("STATUS", typeof(string));// 状态

			Gi01 = new DataTable("Gi01");
			Gi01.Columns.AddRange(new DataColumn[]
				{col_gi001,col_gi002,col_gi003,col_price2,col_gi088,col_sortId2,col_gi099,col_gi077,col_status_2,col_gi066,col_gi055});
			Gi01.PrimaryKey = new DataColumn[] { col_gi001 };                //设置主键

			this.Tables.Add(Gi01);

			gi01Adapter = new OracleDataAdapter("select * from gi01 where gi002 = :gi002  order by gi002,sortId", SqlAssist.conn);
			gi01Adapter.Requery = true;

			gibuilder = new OracleCommandBuilder(gi01Adapter);
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 

			Ii01 = new DataTable("Ii01");
			ii01Adapter = new OracleDataAdapter("select * from v_invoiceItems", SqlAssist.conn);
			ii01Adapter.Fill(Ii01);
		}

		public void Fill_Si01()
		{
			Si01.Rows.Clear();
			this.si01Adapter.Fill(Si01);
		}

		public void Fill_Gi01()
		{
			Gi01.Rows.Clear();
			this.gi01Adapter.Fill(Gi01);
		}
	}
}
