using Jaguar.Action;
using Jaguar.BaseObject;
using Jaguar.Misc;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaguar.Forms
{
	public partial class Frm_FinInvoice : BaseDialog
	{
		private string s_fa001 = string.Empty;
		private string s_inv_batch_code = string.Empty;
		private string s_inv_no = string.Empty;
		public Frm_FinInvoice()
		{
			InitializeComponent();
		}

		private void Frm_FinInvoice_Load(object sender, EventArgs e)
		{
			try
			{
                string imgTxt = string.Empty;



				//string imgTxt = FinInvoice.GetInvoiceImageBase64(s_inv_batch_code, s_inv_no);
				imgTxt = "iVBORw0KGgoAAAANSUhEUgAAAK8AAACvCAIAAAAE8BkiAAAFvUlEQVR42u3d227bMBBFUf//T6dPQdEEkYdz9oxUZOvRtS2KXAbnQqSvDy+vz+vlFHh91fDKrr9f9+2Vyj99f0/vm4/u3htqZYRHE3V0r96b6wNTgxrUoIaKhrNt5mSBj76QWqrQx5HOUDD17MkKqkENalDDkQY8SuhtfnhsgePGY51w6pIVVIMa1KCGBQ1hlhXeordl4tk1npxTPz81qEENaniUBlzMXLkTT/aofFsNalCDGh6uoTe4zS0cz11xVXjijTtTgxrUoIaGBjxN8pXlVx592sVX1OAr/7MG6sILamFziIob8PCFyh7h5VODGtSghp814HNEdWXmMszNEiTFnQrvgHqDGtSghl+sYaEB3zuX8JA1623qvagFr8y+HYYa1KAGNVxo6OVm4bOFSxXWRu+tqOItrjB4UoMa1KCGetcKb/ZTGdRcOjp3qCKsMyIL";
                byte[] bytes = Convert.FromBase64String(imgTxt);
                MemoryStream ms = new MemoryStream(bytes, true);
                ms.Write(bytes, 0, bytes.Length);
                pictureBox1.Image = new Bitmap(ms);
            }
			catch (Exception ee)
			{
				LogUtils.Error(ee.ToString());
				pictureBox1.Image = Jaguar.Properties.Resources.nodata;
			}

		}
		/// <summary>
		/// 打印电子票
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			//PrintDocument pd = new PrintDocument();
			////设置边距
			//Margins margin = new Margins(10, 10, 20, 20);
			//pd.DefaultPageSettings.Margins = margin;
			//pd.DefaultPageSettings.Landscape = false;

			//////纸张设置默认
			////foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
			////{
			////	if (ps.PaperName.Equals("A4"))
			////		pd.DefaultPageSettings.PaperSize = ps;
			////}
			//PaperSize pageSize = new PaperSize("First custom size", 260, 160);
			//pd.DefaultPageSettings.PaperSize = pageSize;

			////打印事件设置
			//pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
			////ppd.Document = pd;
			////ppd.ShowDialog();
			//try
			//{
			//	pd.Print();
			//	XtraMessageBox.Show("电子票打印完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
			//}

			string s_pictureName = "einvoice.png";
			if (pictureBox1.Image != null && pictureBox1.Image != Jaguar.Properties.Resources.nodata)
			{
				////********************照片另存*********************************
				using (MemoryStream mem = new MemoryStream())
				{
					//这句很重要，不然不能正确保存图片或出错（关键就这一句）
					Bitmap bmp = new Bitmap(pictureBox1.Image);

					//保存到内存
					//bmp.Save(mem, pictureBox1.Image.RawFormat );
					//保存到磁盘文件
					bmp.Save(s_pictureName, pictureBox1.Image.RawFormat);
					bmp.Dispose();

					PrtServAction.Print_EInvoice(Envior.mform.Handle.ToInt32());
				}
				////********************照片另存*********************************
			}



		}

		//打印事件处理
		private void pd_PrintPage(object sender, PrintPageEventArgs e)
		{
			//读取图片模板
			Image temp = pictureBox1.Image; // Image.FromFile(@"Receipts.jpg");

			int x = e.MarginBounds.X;
			int y = e.MarginBounds.Y;
			int width = temp.Width;
			int height = temp.Height;
			Rectangle destRect = new Rectangle(x, y, width, height - 80);
			e.Graphics.DrawImage(temp, destRect, 0, 0, temp.Width, temp.Height, System.Drawing.GraphicsUnit.Pixel);
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string s_pictureName = saveFileDialog1.FileName; 
				if (pictureBox1.Image != null && pictureBox1.Image != Jaguar.Properties.Resources.nodata)
				{
					////********************照片另存*********************************
					using (MemoryStream mem = new MemoryStream())
					{
						//这句很重要，不然不能正确保存图片或出错（关键就这一句）
						Bitmap bmp = new Bitmap(pictureBox1.Image);

						//保存到内存
						//bmp.Save(mem, pictureBox1.Image.RawFormat );
						//保存到磁盘文件
						bmp.Save(s_pictureName, pictureBox1.Image.RawFormat);
						bmp.Dispose();						 
						XtraMessageBox.Show("图片另存成功！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
					////********************照片另存*********************************
				}
			}
		}
	}
}
