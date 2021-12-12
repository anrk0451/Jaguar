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

namespace Jaguar.Forms
{
	public partial class Frm_report_regdebt : BaseDialog
	{
		public Frm_report_regdebt()
		{
			InitializeComponent();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.swapdata["type"] = radioGroup1.EditValue;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}