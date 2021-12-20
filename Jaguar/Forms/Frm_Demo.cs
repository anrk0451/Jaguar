using DevExpress.XtraEditors;
using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

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
        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:8080/scanner/CreateCharge");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            StringBuilder sb_1 = new StringBuilder();
            sb_1.Append("merchant_no=2300002021121301&");
            sb_1.Append("private_key=MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAN1EdZmGwr+nUNilQHPJAQmJdNje5ULGPol7EweneeTWci59IzdZZqgg2N3bAUvYvC4Y9G2jFKGg1OC4vYNkuuvprKFNSyX8xLFxlRpTPPqCuYHtXaF2rGYvGgzjdW2DYDQUbrq+ZT0wVezmgGTkNITu5P3dIsRRtDG7s3uFyN8nAgMBAAECgYAnvdMNdynleGzJ7Kxt321jRCALj8VHwAmdcdCSMF9xXZ72gJ1hpJoOmo+5EUvjTpNGCE9mncLn4NY7YpMPVXlI7phAlRAu5tZZG/ctsZhXFOkqO1SPD3rl53u80MkfJ82rIVTx0LQG5tc69nCxqC3NmWns9T++BakxoyeknMzXoQJBAPDIx0K1ALgrq/cGwJBZDgGyjkCBrw1+GR7oLAwTdL/3bkdfvjUxOO7d34wyZnh7uqPspp6WEJlCMPpJuvdftfcCQQDrP/PDR1odtMuT6IxrDEYqxI0OQL35hpG8fkCF0+QVDnQBYiu3P3cAw8Myr8W5vrXo8FRN9Dfl9b+AujRVvxRRAkEA4xOWx9RHn2igPtFBXWB/Ex6/hRpIaqMXMcynbaQToM7KU8l5alTHao4YOvF1Lf8R33JZGIpRkReZdRF/n7fFtQJBAN2kSVQo+5yVZGCcbv/Edq+As61EDjj0Moa3JK9x7ahxD5bmGW3zG3na9yPgO5g/OECZfbRcbfX5TU5JIVnQR6ECQFm+MIjSESLBzcPFqYbpYfCn2VocnrumAa27ile/0RUDxp2CIbTazFhkUbmriXRSw2K31mQmQQMqvQKLb2rQdrE=&");
            sb_1.Append("merchant_order_no=0000012345&");
            sb_1.Append("amount=50&");
            //sb_1.Append("charge_param=&");
            //sb_1.Append("back_url=http://localhost:8080/scanner/SettleNotice&");


            byte[] data = Encoding.UTF8.GetBytes(sb_1.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("GB2312"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            memoEdit1.Text = retString;


        }

		private void simpleButton2_Click(object sender, EventArgs e)
		{
            System.Drawing.Bitmap bt;
            string enCodeString = memoEdit1.Text;
                ////"https://debug.epayservice.cn/thirdpay/charge/qrcode.do?mac=f2b3bd5b25020b642e40a30bb2e8&t=21121810140946835&m=2300002021121301&e=1c&v=1.1&d=phone&r=230601";

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            qrCodeEncoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeBackgroundColor = Color.White;//背景色
            qrCodeEncoder.QRCodeForegroundColor = Color.Black;//前景色

            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

            string filename = "code";
            string file_path = "d:\\";
            string codeUrl = file_path + filename + ".jpg";

            //根据文件名称，自动建立对应目录
            if (!System.IO.Directory.Exists(file_path))
                System.IO.Directory.CreateDirectory(file_path);

            bt.Save(codeUrl);//保存图片
            pictureBox1.Image = Image.FromFile(codeUrl);
        }
	}
}