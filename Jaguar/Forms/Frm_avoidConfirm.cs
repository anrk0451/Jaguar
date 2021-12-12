using DevExpress.XtraEditors;
using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
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
    public partial class Frm_avoidConfirm : BaseDialog
    {
        private string ac001 = string.Empty;
        private DataTable dt_ac12 = new DataTable("AC12");
        private OracleDataAdapter ac12Adapter = new OracleDataAdapter("",SqlAssist.conn);
        public Frm_avoidConfirm()
        {
            InitializeComponent();
        }

        private void Frm_avoidConfirm_Load(object sender, EventArgs e)
        {
            ac001 = this.swapdata["ac001"].ToString();
            ac12Adapter.SelectCommand.CommandText = "select * from ac12 where ac001 = '" + ac001 + "'";
            ac12Adapter.Fill(dt_ac12);
            gridControl1.DataSource = dt_ac12;
            gridView1.CustomDrawRowIndicator += AppAction.DrawGridLineNo;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName.ToUpper() == "AC033")
            {
                if (e.Value.ToString() == "01" || e.Value.ToString() == "02")
                    e.DisplayText = "遗体存放";
                else if (e.Value.ToString() == "06")
                    e.DisplayText = "火化";
                else if (e.Value.ToString() == "07")
                    e.DisplayText = "接运";
                else if (e.Value.ToString() == "08")
                    e.DisplayText = "骨灰寄存";
            }
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("确认要继续吗? 预收款将全部返还！","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(FireAction.AvoidConfirm(ac001,Envior.cur_userId) > 0)
                {
                    XtraMessageBox.Show("办理成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}