using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaguar.DataSet
{
    class Register_ds : System.Data.DataSet
    {
		public DataTable Rc01 { get; }                   //寄存信息
		public DataTable Jcfp { get; }                   //寄存附品
		public DataTable Sa01 { get; }                   //附品销售记录
		public DataTable RegCombo { get; }               //寄存服务套餐
		public DataTable Relation { get; }               //与逝者关系
		public DataTable Avoid { get; }					 //减免类型
		public DataTable Room { get; }					 //寄存室

		public OracleDataAdapter rc01Adapter { get; }
		public OracleDataAdapter jsfpAdapter { get; }
		public OracleDataAdapter rcAdapter { get; }
		public OracleDataAdapter rlAdapter { get; }
		public OracleDataAdapter avoidAdapter { get; }
		public OracleDataAdapter sa01Adapter { get; }
		public OracleDataAdapter roomAdapter { get; }

		public Register_ds()
		{
			Rc01 = new DataTable("Rc01");
			Jcfp = new DataTable("Jcfp");
			Sa01 = new DataTable("Sa01");
			RegCombo = new DataTable("RegCombo");
			Relation = new DataTable("Relation");
			Avoid = new DataTable("Avoid");
			Room = new DataTable("Room");

			this.Tables.Add(Rc01);
			this.Tables.Add(Jcfp);
			this.Tables.Add(RegCombo);
			this.Tables.Add(Relation);
			this.Tables.Add(Sa01);
			this.Tables.Add(Avoid);

			rc01Adapter =
				new OracleDataAdapter("select * from v_register where trunc(sysdate) - trunc(rc200) < :days order by rc001 desc", SqlAssist.conn);
			jsfpAdapter =
				new OracleDataAdapter("select * from V_ALLVALIDITEM where item_type in ( '13','12')", SqlAssist.conn);
			rcAdapter =
				new OracleDataAdapter("select * from cb02 where cb001 in (select cb001 from cb01 where cb002 = '0' and cb005 = '08' and status = '1') order by cb022", SqlAssist.conn);
			rlAdapter =
				new OracleDataAdapter("select * from st01 where status = '1' and st002 = 'RELATION' order by st002,sortId", SqlAssist.conn);

			sa01Adapter = new OracleDataAdapter("select * from sa01 where 1<0", SqlAssist.conn);

			avoidAdapter =
				new OracleDataAdapter("select * from st01 where status = '1' and st002 = 'AVOIDTYPE' order by st002,sortId", SqlAssist.conn);
			roomAdapter =
				new OracleDataAdapter("select rg001,pkg_business.fun_getRoomName(rg001) rg003 from rg01 where status = '1' and rg002 = '2' order by rg001", SqlAssist.conn);

			jsfpAdapter.Fill(Jcfp);
			rcAdapter.Fill(RegCombo);
			rlAdapter.Fill(Relation);
			avoidAdapter.Fill(Avoid);
			roomAdapter.Fill(Room);

			///必须Fill一下 否则表格无法更新输入!!!
			sa01Adapter.Fill(Sa01);
		}
	}
}
