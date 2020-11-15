using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brown.Action
{
	class P_detail
	{
		public string chargeCode;
		public string chargeName;
		public decimal? std;
		public decimal? number;
		public decimal? amt;
		public P_detail()
		{
			chargeCode = string.Empty;
			chargeName = string.Empty;
			std = 0;
			number = 0;
			amt = 0;
		}
	};
	class C_params
	{
		public string region { get; set; }
		public string deptcode { get; set; }
		public string appid { get; set; }
		public string data { get; set; }
		public string noise { get; set; }
		public string version { get; set; }
		public string sign { get; set; }
	}
	class FinInvoice2
	{
		/// <summary>
		/// 返回下一张 财政发票 号码
		/// </summary>
		/// <returns></returns>
		//public static int GetInvoiceNextNum(string invoiceCode)
		//{
		//	//Envior.NEXT_BILL_CODE = "3610";
		//	//Envior.NEXT_BILL_NUM = "00123456";

		//	Dictionary<string, string> bdata = new Dictionary<string, string>();

		//	//开票点编码
		//	bdata.Add("placeCode", "001");
		//	bdata.Add("bill_batch_code", "3910");

		//	string s_json = Tools.ConvertObjectToJson(bdata);
		//	string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

		//	Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("stock.billno.get", s_business_base64));

		//	if (retdata != null)
		//	{
		//		if (retdata["result"].ToString() == "S0000")
		//		{
		//			s_business_base64 = retdata["message"].ToString();
		//			Dictionary<string, string> d_result = null;
		//			s_json = Tools.DecodeBase64("utf-8", s_business_base64);                        //base64解码为json 
		//			d_result = JsonConvert.DeserializeObject<Dictionary<string, string>>(s_json);   //json ==》 对象

		//			if (d_result.ContainsKey("pBillBatchCode") && d_result.ContainsKey("pBillNo"))
		//			{
		//				Envior.NEXT_BILL_CODE = d_result["pBillBatchCode"];
		//				Envior.NEXT_BILL_NUM = d_result["pBillNo"];
		//				return 1;
		//			}
		//			else
		//			{
		//				MessageBox.Show("接收的数据结构错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		//				return -1;
		//			}
		//		}
		//		else
		//		{
		//			s_business_base64 = retdata["message"].ToString();
		//			MessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		//			return -1;
		//		}
		//	}
		//	else
		//	{
		//		MessageBox.Show("接收数据失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		return -1;
		//	}

		//}

		/// <summary>
		/// 向博思服务端 发送请求
		/// </summary>
		/// <param name="command"></param>
		/// <param name="businessData"></param>
		/// <returns></returns>        
		//public static string SendInvoiceRequest(string command, string businessData)
		//{
		//	StringBuilder sb_link = new StringBuilder(100);
		//	string s_sign = string.Empty;
		//	string s_json = string.Empty;
		//	string s_noise = string.Empty;

		//	sb_link.Append("region=" + "231001" + "&");
		//	sb_link.Append("deptcode=" + "021099001" + "&");
		//	sb_link.Append("appid=" + "MDJSDYBYG7838387" + "&");
		//	sb_link.Append("data=" + businessData + "&");                         //业务数据 做 Base64编码

		//	s_noise = Guid.NewGuid().ToString("N");

		//	sb_link.Append("noise=" + s_noise + "&");
		//	sb_link.Append("key=" + "0d3ae7af6c20c68a89390a6ec445" + "&");
		//	sb_link.Append("version=" + "1.0.1");

		//	//////// 计算签名 //////////
		//	s_sign = Tools.EncryptWithMD5(sb_link.ToString()).ToUpper();

		//	////构建发送博思服务端数据
		//	InvoiceRequestData reqdata = new InvoiceRequestData();
		//	reqdata.region = Envior.invoice_region;
		//	reqdata.deptcode = Envior.invoice_dept;
		//	reqdata.appid = Envior.invoice_appid;
		//	reqdata.data = businessData;                   //业务数据,再经过base64编码
		//	reqdata.noise = s_noise;
		//	reqdata.version = Envior.invoice_ver;
		//	reqdata.sign = s_sign;

		//	s_json = Tools.ConvertObjectToJson(reqdata);

		//	string s_url = AppInfo.BOSI_API_ADDR + command;
		//	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s_url);
		//	request.Method = "POST";
		//	request.ContentType = "application/json";

		//	byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(s_json);
		//	request.ContentLength = buf.Length;

		//	//request.ContentLength = Encoding.UTF8.GetByteCount(s_json);
		//	//request.ContentLength = Encoding.UTF8.GetBytes(s_json).Length;

		//	Stream myRequestStream = request.GetRequestStream();
		//	myRequestStream.Write(buf, 0, buf.Length);


		//	//StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));

		//	//s_json = @"{"region":"230125","deptcode":"610001","appid":"BXBYG3477584","data":"eyJwbGFjZUNvZGUiOiIwMDEiLCJwQmlsbEJhdGNoQ29kZSI6IjM2MTAifQ == ","noise":"ab8fb017177844d9aeb6a1284cfc07b5","version":"3.1.2.0","sign":"63BFAE4B13DBF7522DF207E9DE35D034"}";
		//	//string ss = Tools.EncodeBase64("utf-8", s_json);

		//	//myStreamWriter.Write(buf,0,buf.Length);
		//	myRequestStream.Close();

		//	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		//	Stream myResponseStream = response.GetResponseStream();
		//	StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
		//	string retString = myStreamReader.ReadToEnd();
		//	myStreamReader.Close();
		//	myResponseStream.Close();

		//	InvoiceResponseData repdata = JsonConvert.DeserializeObject<InvoiceResponseData>(retString);

		//	return Tools.DecodeBase64("utf-8", repdata.data);
		//}


	}
}
