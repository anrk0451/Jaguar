using DevExpress.XtraEditors;
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

namespace Jaguar.Forms
{
	public partial class Frm_CashSearch : BaseDialog
	{
		private string s_ac001 = string.Empty;
		private DataTable dt_ac02 = new DataTable("ac02");
		private OracleDataAdapter ac02Adapter = new OracleDataAdapter("select * from ac02 where ac001 = :ac001 order by ac200",SqlAssist.conn);

		private OracleParameter op_ac001 = new OracleParameter("ac001", OracleDbType.Varchar2, 10);

		public Frm_CashSearch()
		{
			InitializeComponent();
		}

		private void Frm_CashSearch_Load(object sender, EventArgs e)
		{
			gridView1.CustomDrawRowIndicator += AppAction.DrawGridLineNo;
			gridControl1.DataSource = dt_ac02;
			s_ac001 = this.swapdata["ac001"].ToString();
			ac02Adapter.SelectCommand.Parameters.Add(op_ac001);
			op_ac001.Value = s_ac001;
			ac02Adapter.Fill(dt_ac02);

		}

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if(e.Column.FieldName.ToUpper() == "AC100")
			{
				e.DisplayText = MiscAction.Mapper_operator(e.Value.ToString());
			}
			 
		}

		 
	}
}