using DevExpress.XtraEditors;
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
	public partial class Frm_SetAvoid : BaseDialog
	{
		private string s_ac001 = string.Empty;
		private DataTable dt_st01 = new DataTable("st01");
		private OracleDataAdapter st01Adapter = new OracleDataAdapter("select * from st01 where st002 = 'AVOIDTYPE' and status = '1' order by sortId ", SqlAssist.conn);

		public Frm_SetAvoid()
		{
			InitializeComponent();
		}

		private void Frm_SetAvoid_Load(object sender, EventArgs e)
		{
			s_ac001 = this.swapdata["ac001"].ToString();
			st01Adapter.Fill(dt_st01);
			lookup_ac070.Properties.DataSource = dt_st01;

			using (OracleDataReader reader = SqlAssist.ExecuteReader("select ac003,ac070 from ac01 where ac001='" + s_ac001 + "'"))
			{
				if(reader.HasRows && reader.Read())
				{
					te_ac003.EditValue = reader["AC003"];
					lookup_ac070.EditValue = reader["AC070"];
				}
			}
			 
		}

		private void b_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void b_ok_Click(object sender, EventArgs e)
		{
			string s_ac070 = lookup_ac070.EditValue.ToString();
			this.swapdata["ac070"] = s_ac070;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}