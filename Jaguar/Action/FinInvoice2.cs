using DevExpress.XtraEditors;
using Jaguar.Misc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaguar.Action;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Jaguar.Action
{
    class FinInvoice2
    {
		class C_detail
		{
			public string chargeCode;
			public string chargeName;
			public decimal? std;
			public decimal? number;
			public decimal? amt;
			public C_detail()
			{
				chargeCode = string.Empty;
				chargeName = string.Empty;
				std = 0;
				number = 0;
				amt = 0;
			}
		};

		class C_notice
        {
			public string code;
			public string value;
			public C_notice()
            {
				code = string.Empty;
				value = string.Empty;
            }
        }


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

		/// <summary>
		/// 开具财政发票(电子票)
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static int Invoice(string fa001)
		{
			try
			{

				string s_invcode = string.Empty;
				decimal dec_hjje = decimal.Zero;

				//做开具财政发票前的预处理!!!
				if (MiscAction.FinInvoicePrePare(fa001) < 0) return -1;


				DataTable dt_detail = new DataTable();
				OracleDataAdapter sa01Adapter = new OracleDataAdapter("select * from fa05 where fa001 = :fa001", SqlAssist.conn);
				OracleParameter op_fa001 = new OracleParameter("fa001", OracleDbType.Varchar2, 10);
				op_fa001.Direction = ParameterDirection.Input;

				sa01Adapter.SelectCommand.Parameters.Add(op_fa001);
				op_fa001.Value = fa001;
				sa01Adapter.Fill(dt_detail);

				OracleDataReader fa01 = SqlAssist.ExecuteReader("select * from fa01 where fa001='" + fa001 + "'");
				if (!fa01.HasRows)
				{
					XtraMessageBox.Show("未找到结算记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}

				Dictionary<string, object> bdata = new Dictionary<string, object>();
				List<C_detail> detaildata = new List<C_detail>();

				while (fa01.Read())
				{
					bdata.Add("busNo", "DQBYG" + fa001);                                     //业务流水号
					bdata.Add("busDateTime", Convert.ToDateTime(fa01["FA200"]).AddDays(-1).ToString("yyyyMMddHHmmssfff"));  //业务发生时间(提前一天)
					//bdata.Add("billDate", MiscAction.GetServerTime().ToString("yyyyMMddHHmmssfff"));//开票时间
					bdata.Add("placeCode", Envior.FIN_BILL_SITE);							 //开票点编码
					bdata.Add("billCode", Envior.FIN_CODE);									 //票据种类编码(填写系统内部编码值)
					//bdata.Add("billBatchCode", Envior.NEXT_BILL_CODE);                       //票据代码(注册号)
					//bdata.Add("billNo", Envior.NEXT_BILL_NUM);                               //票据号
					bdata.Add("payer", fa01["FA003"].ToString());                             //交款人
					bdata.Add("payerType", "1");                                              //交款人类型 1-个人 2-单位
					bdata.Add("payee", MiscAction.Mapper_operator(fa01["FA100"].ToString())); //收费员
					bdata.Add("author", Envior.cur_userName);                                 //开票人
					bdata.Add("payChannel", "02");                                            //交费渠道 02-现金					 
					bdata.Add("remark", fa01["FA180"]);                                       //备注
				}
				fa01.Dispose();
				 
				foreach (DataRow dr in dt_detail.Rows)
				{
					s_invcode = dr["INVOICECODE"].ToString();
					if (string.IsNullOrEmpty(s_invcode))
					{
						XtraMessageBox.Show(dr["SA003"] + "没有设置财政发票编码!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return -1;
					}
					 
					C_detail str_detail = new C_detail();
					str_detail.chargeCode = s_invcode;
					str_detail.chargeName = MiscAction.MapperFinanceItemName(s_invcode);
					str_detail.std = Convert.ToDecimal(dr["PRICE"]);
					str_detail.number = Convert.ToDecimal(dr["NUMS"]);
					str_detail.amt = Convert.ToDecimal(dr["FEE"]);
					detaildata.Add(str_detail);

					dec_hjje += Convert.ToDecimal(dr["FEE"]);
				}
				bdata.Add("chargeDetail", detaildata);
				bdata.Add("totalAmt",dec_hjje);         
				 
				string s_json = Tools.ConvertObjectToJson(bdata);				 
				string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

				Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("invoiceEBill", s_business_base64));
				if (retdata != null)
				{
					if (retdata["result"].ToString() == "S0000")
					{
						s_business_base64 = retdata["message"].ToString();
						Dictionary<string, string> d_result = null;
						s_json = Tools.DecodeBase64("utf-8", s_business_base64);                        //base64解码为json 
						d_result = JsonConvert.DeserializeObject<Dictionary<string, string>>(s_json);   //json ==》 对象

						/////更新财务发票日志
						//string s_billCode = d_result["billCode"].ToString();
						string s_billBatchCode = d_result["billBatchCode"].ToString();
						string s_billNo = d_result["billNo"].ToString();
						string s_random = d_result["random"].ToString();
						string s_kpsj = d_result["createTime"].ToString();
						string s_pic = d_result["billQRCode"].ToString();
						string s_pic_url = d_result["pictureUrl"].ToString();
						string s_bus_no = d_result["busNo"].ToString();
						 
						if (FinInvoiceLog(fa001, Envior.FIN_CODE, s_billNo, s_billBatchCode, dec_hjje, Envior.cur_userId,s_random,s_kpsj,s_pic,s_pic_url) > 0)
						{
							XtraMessageBox.Show("财政电子票开具成功!\r\n" + "注册号:" + s_billBatchCode + "\r\n" + "票据号:" + s_billNo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							XtraMessageBox.Show("电子票开具成功!!!但记录日志失败，请与管理员联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							XtraMessageBox.Show("票据号:" + s_billNo + "\r\n注册号:" + s_billBatchCode + "\r\n");
						}

						return 1;
					}
					else
					{
						s_business_base64 = retdata["message"].ToString();
						XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return -1;
					}
				}
				else
				{
					XtraMessageBox.Show("接收数据失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -1;
				}
			}
			catch (Exception ee)
			{
				XtraMessageBox.Show(ee.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return -1;
			}

		}


		/// <summary>
		/// 向博思服务端 发送请求
		/// </summary>
		/// <param name="command"></param>
		/// <param name="businessData"></param>
		/// <returns></returns>        
		public static string SendInvoiceRequest(string command, string businessData)
		{
			StringBuilder sb_link = new StringBuilder(100);
			string s_sign = string.Empty;
			string s_json = string.Empty;
			string s_noise = string.Empty;

			sb_link.Append("region=" + Envior.FIN_REGION_CODE + "&");
			sb_link.Append("deptcode=" + Envior.FIN_AGENCY_CODE + "&");
			sb_link.Append("appid=" + Envior.FIN_APPID + "&");
			sb_link.Append("data=" + businessData + "&");                         //业务数据 做 Base64编码
			s_noise = Guid.NewGuid().ToString("N");

			sb_link.Append("noise=" + s_noise + "&");
			sb_link.Append("key=" + Envior.FIN_APPKEY + "&");
			sb_link.Append("version=" + Envior.FIN_VERSION);

			//////// 计算签名 //////////
			s_sign = Tools.EncryptWithMD5(sb_link.ToString()).ToUpper();

			////构建发送博思服务端数据
			InvoiceRequestData reqdata = new InvoiceRequestData();
			reqdata.region = Envior.FIN_REGION_CODE;
			reqdata.deptcode = Envior.FIN_AGENCY_CODE;
			reqdata.appid = Envior.FIN_APPID;
			reqdata.data = businessData;                   //业务数据,再经过base64编码
			reqdata.noise = s_noise;
			reqdata.version = Envior.FIN_VERSION;
			reqdata.sign = s_sign;

			s_json = Tools.ConvertObjectToJson(reqdata);			 
			string s_url = "http://192.168.1.164:18001/standard-web/api/standard/" + command;

			LogUtils.Info(businessData);
			LogUtils.Info(s_json);
			LogUtils.Info(s_url);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s_url);
			request.Method = "POST";
			request.ContentType = "application/json";
			 
			byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(s_json);
			request.ContentLength = buf.Length;
 
			Stream myRequestStream = request.GetRequestStream();
			myRequestStream.Write(buf, 0, buf.Length);
			 
			myRequestStream.Close();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream myResponseStream = response.GetResponseStream();
			StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
			string retString = myStreamReader.ReadToEnd();
			myStreamReader.Close();
			myResponseStream.Close();

			InvoiceResponseData repdata = JsonConvert.DeserializeObject<InvoiceResponseData>(retString);

			return Tools.DecodeBase64("utf-8", repdata.data);
		}


		/// <summary>
		/// 财政发票开票日志
		/// </summary>
		/// <param name="fa001">结算流水号</param>
		/// <param name="fplx">发票类型</param>
		/// <param name="fph">发票号</param>
		/// <param name="zch">注册号</param>
		/// <returns></returns>
		public static int FinInvoiceLog(string fa001, string fplx, string fph, string zch, decimal hjje, string kpr,string random,string kpsj,string pictrue,string pictrueUrl)
		{
			//逝者编号
			OracleParameter op_fa001 = new OracleParameter("ic_fa001", OracleDbType.Varchar2, 10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;

			//票据类型
			OracleParameter op_pjlx = new OracleParameter("ic_billCode", OracleDbType.Varchar2, 10);
			op_pjlx.Direction = ParameterDirection.Input;
			op_pjlx.Value = fplx;

			//票号
			OracleParameter op_fph = new OracleParameter("ic_billNo", OracleDbType.Varchar2, 10);
			op_fph.Direction = ParameterDirection.Input;
			op_fph.Value = fph;

			//注册号
			OracleParameter op_zch = new OracleParameter("ic_zch", OracleDbType.Varchar2, 20);
			op_zch.Direction = ParameterDirection.Input;
			op_zch.Value = zch;

			//合计金额
			OracleParameter op_hjje = new OracleParameter("in_hjje", OracleDbType.Decimal);
			op_hjje.Direction = ParameterDirection.Input;
			op_hjje.Value = hjje;
			//开票人
			OracleParameter op_kpr = new OracleParameter("ic_kpr", OracleDbType.Varchar2, 10);
			op_kpr.Direction = ParameterDirection.Input;
			op_kpr.Value = kpr;

			//校验码
			OracleParameter op_random = new OracleParameter("ic_random", OracleDbType.Varchar2, 50);
			op_random.Direction = ParameterDirection.Input;
			op_random.Value = random;

			//开票时间
			OracleParameter op_kpsj = new OracleParameter("ic_kpsj", OracleDbType.Varchar2, 30);
			op_kpsj.Direction = ParameterDirection.Input;
			op_kpsj.Value = kpsj;

			//发票图片
			OracleParameter op_pictrue = new OracleParameter("ic_pic", OracleDbType.Varchar2, 500);
			op_pictrue.Direction = ParameterDirection.Input;
			op_pictrue.Value = pictrue;
			//发票图片url
			OracleParameter op_pictrueUrl = new OracleParameter("ic_pic_url", OracleDbType.Varchar2, 100);
			op_pictrueUrl.Direction = ParameterDirection.Input;
			op_pictrueUrl.Value = pictrueUrl;

			return SqlAssist.ExecuteProcedure("pkg_business.prc_FinInvoiceLog",
				new OracleParameter[] { op_fa001, op_pjlx, op_fph, op_zch, op_hjje, op_kpr ,op_random,op_kpsj,op_pictrue,op_pictrueUrl});
		}


		/// <summary>
		/// 打印财政发票
		/// </summary>
		/// <param name="pBillBatchCode"></param>
		/// <param name="pBillNo"></param>
		/// <returns></returns>
		public static int PrintInvoice(string pBillBatchCode, string pBillNo,string random)
		{
			Dictionary<string, string> bdata = new Dictionary<string, string>();

			//业务数据
			bdata.Add("billBatchCode", pBillBatchCode);
			bdata.Add("billNo", pBillNo);
			bdata.Add("random", random);

			string s_json = Tools.ConvertObjectToJson(bdata);
			string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

			StringBuilder sb_link = new StringBuilder(100);
 
			sb_link.Append("appid=" + Envior.FIN_APPID + "&");
			sb_link.Append("data=" + s_business_base64 + "&");                         //业务数据 做 Base64编码

			string s_noise = Guid.NewGuid().ToString("N");

			sb_link.Append("noise=" + s_noise + "&");
			sb_link.Append("key=" + Envior.FIN_APPKEY + "&");
			sb_link.Append("version=" + Envior.FIN_VERSION);

			//////// 计算签名 //////////
			string s_sign = Tools.EncryptWithMD5(sb_link.ToString()).ToUpper();

			StringBuilder sb_send = new StringBuilder(100);
			sb_send.Append("{\"method\":\"printElectBill\",\"params\":");

			Dictionary<string, string> s_data = new Dictionary<string, string>();
			s_data.Add("appid", Envior.FIN_APPID);
			s_data.Add("data", s_business_base64);
			s_data.Add("noise", s_noise);
			s_data.Add("version", Envior.FIN_VERSION);
			s_data.Add("sign", s_sign);

			sb_send.Append(Tools.ConvertObjectToJson(s_data) + "}");

			string s_finish = Tools.EncodeBase64("utf-8", sb_send.ToString());

			string s_url = @"http://127.0.0.1:13526/extend?dllName=NontaxIndustry&func=CallNontaxIndustry&payload=";
			string s_url2 = s_url + s_finish;

			LogUtils.Info("print_url=" + s_url2);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s_url2);
			request.Method = "GET";
			request.ContentType = "application/json";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream myResponseStream = response.GetResponseStream();
			StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
			string retString = myStreamReader.ReadToEnd();

			myStreamReader.Close();
			myResponseStream.Close();

			Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(retString);

			if (retdata != null)
			{
				Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(Tools.DecodeBase64("utf-8", retdata["data"].ToString()));
				if (result["result"].ToString() == "S0000")
				{
					XtraMessageBox.Show("打印发票成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return 1;
				}
				else
				{
					s_business_base64 = result["message"].ToString();
					XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + result["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}
			}
			else
			{
				XtraMessageBox.Show("打印进程通信错误,打印失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
		}
		/// <summary>
		/// 获取电子票据图片Url
		/// </summary>
		/// <param name="pBillBatchCode"></param>
		/// <param name="pBillNo"></param>
		/// <param name="random"></param>
		/// <returns></returns>
		public static string GetEBillImgUrl(string eBillBatchCode, string eBillNo, string random)
        {
			Dictionary<string, object> bdata = new Dictionary<string, object>();
			bdata.Add("billBatchCode", eBillBatchCode);
			bdata.Add("billNo", eBillNo);
			bdata.Add("random", random);
			bdata.Add("channelMode", "02");
			string s_json = Tools.ConvertObjectToJson(bdata);
			string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

			Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("getEBillPicUrl", s_business_base64));

			if (retdata != null)
			{
				if (retdata["result"].ToString() == "S0000")
				{
					s_business_base64 = retdata["message"].ToString();
					Dictionary<string, string> d_result = null;
					s_json = Tools.DecodeBase64("utf-8", s_business_base64);                        //base64解码为json 
					d_result = JsonConvert.DeserializeObject<Dictionary<string, string>>(s_json);   //json ==》 对象
					 
					LogUtils.Info("pic_url ='" + d_result["pictureUrl"].ToString());
					return d_result["pictureUrl"].ToString();
				}
				else
				{
					s_business_base64 = retdata["message"].ToString();
					XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return "";
				}
			}
			else
			{
				XtraMessageBox.Show("未返回数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "";
			}
		}
		/// <summary>
		/// 调用浏览器打印电子发票
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static int CallBrowserPrint(string fa001)
        {
			using (OracleDataReader reader = SqlAssist.ExecuteReader("select invoiceZch,invoiceNo,random from fin_log where settleId='" + fa001 + "'"))
            {
				if(reader.HasRows && reader.Read())
                {
					string s_batch_no = reader["INVOICEZCH"].ToString();
					string s_bill_no = reader["INVOICENO"].ToString();
					string s_random = reader["RANDOM"].ToString();
					string s_url = GetEBillImgUrl(s_batch_no, s_bill_no, s_random);
					if (!string.IsNullOrEmpty(s_url))
					{
						System.Diagnostics.Process.Start(s_url);
						return 1;
					}
					else
						return -1;

				}
                else
                {
					XtraMessageBox.Show("未找到发票数据!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return -1;
                }
            }
        }

		/// <summary>
		/// 财政电子发票冲红(全部冲红)
		/// </summary>
		/// <param name="fa001">冲红收款记录的流水号</param>
		/// <returns></returns>
		public static int Refund(string fa001,string reason)
        {
			decimal dec_hjje = decimal.Zero;
			//原正数发票流水号
			string s_fa001_orig = SqlAssist.ExecuteScalar("select rf300 from refund where rf001 = '" + fa001 + "'").ToString();															  
			using (OracleDataReader reader = SqlAssist.ExecuteReader("select * from fin_log where flag = '1' and settleId = '" + s_fa001_orig + "'"))
            {
				if(reader.HasRows && reader.Read())
                {
					dec_hjje = 0 - Convert.ToDecimal(reader["HJJE"]);
					return Refund(fa001,reader["INVOICEZCH"].ToString(), reader["INVOICENO"].ToString(), dec_hjje, reason);					 
				}
                else
                {
					XtraMessageBox.Show("未找到原开票信息!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return -1;
                }
            }
        }

		/// <summary>
		/// 电子票据冲红
		/// </summary>
		/// <param name="batchCode"></param>
		/// <param name="billNo"></param>
		/// <param name="hjje"></param>
		/// <param name="reason"></param>
		/// <returns></returns>
		public static int Refund(string fa001,string batchCode,string billNo, decimal hjje,string reason)
        {
			//string s_fa001_refund = Tools.GetEntityPK("FA01");
  
			Dictionary<string, object> bdata = new Dictionary<string, object>();
			bdata.Add("billBatchCode", batchCode);
			bdata.Add("billNo",billNo);
			bdata.Add("reason", reason);
			bdata.Add("operator", Envior.cur_userName);
			bdata.Add("busDateTime", MiscAction.GetServerTime().ToString("yyyyMMddHHmmssfff"));
			bdata.Add("placeCode", Envior.FIN_BILL_SITE);

			string s_json = Tools.ConvertObjectToJson(bdata);
			string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

			Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("writeOffEBill", s_business_base64));
			if (retdata != null)
			{
				if (retdata["result"].ToString() == "S0000")
				{
					s_business_base64 = retdata["message"].ToString();
					Dictionary<string, string> d_result = null;
					s_json = Tools.DecodeBase64("utf-8", s_business_base64);                        //base64解码为json 
					d_result = JsonConvert.DeserializeObject<Dictionary<string, string>>(s_json);   //json ==》 对象

					/////更新财务发票日志
					string s_billBatchCode = d_result["eScarletBillBatchCode"].ToString();
					string s_billNo = d_result["eScarletBillNo"].ToString();
					string s_random = d_result["eScarletRandom"].ToString();
					string s_kpsj = d_result["createTime"].ToString();
					string s_pic = d_result["billQRCode"].ToString();
					string s_pic_url = d_result["pictureUrl"].ToString();

					if (FinInvoiceLog(fa001, Envior.FIN_CODE, s_billNo, s_billBatchCode, hjje, Envior.cur_userId, s_random, s_kpsj, s_pic, s_pic_url) > 0)
					{
						XtraMessageBox.Show("红字发票开具成功!\r\n" + "注册号:" + s_billBatchCode + "\r\n" + "票据号:" + s_billNo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						XtraMessageBox.Show("发票开具成功!!!但记录日志失败，请与管理员联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						XtraMessageBox.Show("票据号:" + s_billNo + "\r\n注册号:" + s_billBatchCode + "\r\n");
					}
					return 1;
				}
				else
				{
					s_business_base64 = retdata["message"].ToString();
					XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}
			}
			else
			{
				XtraMessageBox.Show("接收数据失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}	 			 
		}

		/// <summary>
		/// 获取电子票据告知单
		/// </summary>
		/// <param name="batchNo"></param>
		/// <param name="billNo"></param>
		/// <param name="ewm"></param>
		/// <param name="gzd"></param>
		/// <returns></returns>
		public static int GetEBillNotice(string batchNo,string billNo,ref string ewm,ref string gzd)
        {
			Dictionary<string, object> bdata = new Dictionary<string, object>();
			bdata.Add("billBatchCode", batchNo);
			bdata.Add("billNo", billNo);
			bdata.Add("isReturnPic", "1");

			string s_json = Tools.ConvertObjectToJson(bdata);
			string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

			Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("getEBillNotifyPic", s_business_base64));
			if (retdata != null)
			{
				if (retdata["result"].ToString() == "S0000")
				{
					s_business_base64 = retdata["message"].ToString();
					Dictionary<string, string> d_result = null;
					s_json = Tools.DecodeBase64("utf-8", s_business_base64);                        //base64解码为json 
					d_result = JsonConvert.DeserializeObject<Dictionary<string, string>>(s_json);   //json ==》 对象


					ewm = d_result["billQRCode"].ToString();
					gzd = d_result["pictureData"].ToString();
					return 1;
				}
				else
				{
					s_business_base64 = retdata["message"].ToString();
					XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}
			}
			else
			{
				XtraMessageBox.Show("接收数据失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
			 
		}
		/// <summary>
		/// 发送电子票通知
		/// </summary>
		/// <param name="batchNo"></param>
		/// <param name="billNo"></param>
		/// <param name="phone"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public static int SendNotice(string batchNo,string billNo,string phone,string email)
        {
			Dictionary<string, object> bdata = new Dictionary<string, object>();
			bdata.Add("billBatchCode", batchNo);
			bdata.Add("billNo", billNo);

			C_notice notice;
			List<C_notice> noticeList = new List<C_notice>();

			if (!string.IsNullOrEmpty(phone))
            {
				notice = new C_notice();
				notice.code = "1201";
				notice.value = phone;
				noticeList.Add(notice);
			}
			if (!string.IsNullOrEmpty(email))
			{
				notice = new C_notice();
				notice.code = "1202";
				notice.value = email;
				noticeList.Add(notice);
			}
 
			bdata.Add("noticeInfo", noticeList); 
			string s_json = Tools.ConvertObjectToJson(bdata);
			LogUtils.Debug(s_json);

			string s_business_base64 = Tools.EncodeBase64("utf-8", s_json);

			Dictionary<string, object> retdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(SendInvoiceRequest("noticeEBill", s_business_base64));
			if (retdata != null)
			{
				if (retdata["result"].ToString() == "S0000")
				{					 
					return 1;
				}
				else
				{
					s_business_base64 = retdata["message"].ToString();
					XtraMessageBox.Show(Tools.DecodeBase64("utf-8", s_business_base64), "错误" + retdata["result"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return -1;
				}
			}
			else
			{
				XtraMessageBox.Show("接收数据失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
		}


	}
}
