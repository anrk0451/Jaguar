using DevExpress.XtraEditors;
using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
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
    public partial class Frm_Demo : BaseDialog
    {
        public Frm_Demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s_batch_no = textEdit1.Text;
            string s_bill_no = textEdit2.Text;
            decimal dec_hjje = Convert.ToDecimal(textEdit3.Text);

			FinInvoice2.Refund( "", "测试数据");
		 

		}

        private void button2_Click(object sender, EventArgs e)
        {
            string s_batch = "23013321";
            string s_bill = "0030170865";
            string ewm = string.Empty, gzd = string.Empty;
            if(FinInvoice2.GetEBillNotice(s_batch,s_bill,ref ewm,ref gzd) > 0)
            {
                memoEdit1.Text = ewm;
                memoEdit2.Text = gzd;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s_batch = "23013321";
            string s_bill = "0030170877";
            if(FinInvoice2.SendNotice(s_batch,s_bill,"18686793872","anrk0451@aliyun.com") > 0)
            {
                XtraMessageBox.Show("发送通知成功!","提示");
            }
        }
    }
}