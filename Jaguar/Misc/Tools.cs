﻿using DevExpress.XtraSplashScreen;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;

namespace Jaguar
{
	public class Tools
    {
        private static string KeyContainerName = "zico";

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public static String Encryption(string express)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = KeyContainerName;  //密匙容器的名称，保持加密解密一致才能解密成功

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);   //将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);           //将加密后的字节数组转换为字符串
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = KeyContainerName;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
        public static string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }

        //// 实体主键生成器
        public static string GetEntityPK(string entity)
        {

            OracleCommand cmd = new OracleCommand("pkg_business.fun_EntityPk", SqlAssist.conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            OracleParameter returnValue = new OracleParameter("result", OracleDbType.Varchar2, 50);
            returnValue.Direction = ParameterDirection.ReturnValue;

            OracleParameter entityName = new OracleParameter("EntityName", OracleDbType.Varchar2, 50);
            entityName.Direction = ParameterDirection.Input;
            entityName.Size = 50;
            entityName.Value = entity;

            try
            {
                cmd.Parameters.Add(returnValue);
                cmd.Parameters.Add(entityName);

               cmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("获取实体主键错误!\n" + e.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
            }

            return returnValue.Value.ToString();
        }

        /// <summary>
        /// 身份证号校验 18位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;
            }
            return true;//正确
        }


        /// <summary>
        /// 身份证校验 15位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }
            return true;//正确
        }

  
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {   //字母和符号原样保留     
                    tempStr += c.ToString();
                }
                else
                {
                    //累加拼音声母
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        private static string GetPYChar(string c)
        {
            if (string.IsNullOrEmpty(c.Trim())) return c;
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <param name="password">密码</param>   
        /// <returns>解压结果</returns>   
        public static bool UnZip(string fileToUnZip, string zipedFolder, string password)
        {
            bool result = true;
            FileStream fs = null;
            ZipInputStream zipStream = null;
            ZipEntry ent = null;
            string fileName;

            if (!File.Exists(fileToUnZip))
                return false;

            if (!Directory.Exists(zipedFolder))
                Directory.CreateDirectory(zipedFolder);

            try
            {
                zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                while ((ent = zipStream.GetNextEntry()) != null)
                {
                    if (!string.IsNullOrEmpty(ent.Name))
                    {
                        fileName = Path.Combine(zipedFolder, ent.Name);
                        fileName = fileName.Replace('/', '\\');//change by Mr.HopeGi   

                        if (fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }

                        fs = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[size];
                        while (true)
                        {
                            size = zipStream.Read(data, 0, data.Length);
                            if (size > 0)
                                fs.Write(data, 0, data.Length);
                            else
                                break;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (zipStream != null)
                {
                    zipStream.Close();
                    zipStream.Dispose();
                }
                if (ent != null)
                {
                    ent = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return result;
        }

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <returns>解压结果</returns>   
        public static bool UnZip(string fileToUnZip, string zipedFolder)
        {
            bool result = UnZip(fileToUnZip, zipedFolder, null);
            return result;
        }

		/// <summary>
		/// 检查版本号
		/// </summary>
		/// <returns></returns>
		public static string getNewVersion()
		{
			return SqlAssist.ExecuteScalar("select nvl(max(verId),'') from fv01", null).ToString();
		}

		public static void DownloadNew(string newfile)
		{
			SplashScreenManager.ShowDefaultWaitForm("请等待", "下载中....");

			string sql = "select ufile from fv01 where verId=(select max(verId) from fv01)";  //从数据库取
			OracleCommand cmd = new OracleCommand(sql, SqlAssist.conn);

			OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
			int bufferSize = 10240;

			if (dr.Read())
			{
				string path = Directory.GetCurrentDirectory() + "\\" + newfile + ".zip";   //需要预先在项目文件夹中建立此目录
				FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
				byte[] buf = new byte[bufferSize];
				long bytesRead = 0;
				long startIndex = 0;

				//LargePhoto的数据比较大，因此分批次读出，分别写入文件
				while ((bytesRead = dr.GetBytes(0, startIndex, buf, 0, bufferSize)) > 0)
				{
					fs.Write(buf, 0, (int)bytesRead);
					startIndex += bytesRead;
				};
				fs.Flush();
				fs.Close();

				UnZip(path, newfile);
				File.Delete(path);

				SplashScreenManager.CloseDefaultWaitForm();
			}
		}

        /// <summary>
        /// 转换对象到 Json 字符串
        /// </summary>
        /// <returns></returns>
        public static string ConvertObjectToJson(Object source)
        {
            //Dictionary<string, object> dict_1 = new Dictionary<string, object>();
            //dict_1.Add("region", "南岗区");
            //dict_1.Add("name", "张三");
            //dict_1.Add("age", 99);
            return Newtonsoft.Json.JsonConvert.SerializeObject(source);
        }

        ///Base64 位 编码
        public static string EncodeBase64(string code_type, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }

        ///Base64 解码
        public static string DecodeBase64(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }



		/// <summary>
		///  AES 加密
		/// </summary>
		/// <param name="str">明文（待加密）</param>
		/// <param name="key">密文</param>
		/// <returns></returns>
		public static string AesEncrypt(string str, string key)
		{
			if (string.IsNullOrEmpty(str)) return null;
			Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

			RijndaelManaged rm = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(key),
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			ICryptoTransform cTransform = rm.CreateEncryptor();
			Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		public static Byte[] AesEncrypt2(string str, string key)
		{
			if (string.IsNullOrEmpty(str)) return null;
			Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

			RijndaelManaged rm = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(key),
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			ICryptoTransform cTransform = rm.CreateEncryptor();
			Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return resultArray;
		}


		/// <summary>
		///  AES 解密
		/// </summary>
		/// <param name="str">明文（待解密）</param>
		/// <param name="key">密文</param>
		/// <returns></returns>
		public static string AesDecrypt(string str, string key)
		{
			if (string.IsNullOrEmpty(str)) return null;
			Byte[] toEncryptArray = Convert.FromBase64String(str);

			RijndaelManaged rm = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(key),
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			ICryptoTransform cTransform = rm.CreateDecryptor();
			Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return Encoding.UTF8.GetString(resultArray);
		}

        /// <summary>
        /// 判断字符是否是汉字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsHZ(string text)
        {
            return Regex.IsMatch(text, @"[\u4E00-\u9FA5]+$");
             
        }

        /// <summary>
        /// 返回本机的ip地址
        /// </summary>
        /// <returns></returns>
        public static void GetIpAddress(out string hostname,out string ipaddress)
        {
            hostname = Dns.GetHostName();                        //本机名 
            IPAddress[] ipHost = Dns.GetHostAddresses(hostname); //会返回所有地址，包括IPv4和IPv6   
            string ipaddr = string.Empty;

            foreach (IPAddress ip in ipHost)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ipaddr = ip.ToString();
            }

            ipaddress = ipaddr;
        }

        public static int Remove4(int num)
		{
            while(num.ToString().IndexOf('4') >= 0)
			{
                num++;
			}
            return num;
		}

  //      /// <summary>
  //      /// 将Base64字符串转换为图片并保存到本地
  //      /// </summary>
  //      /// <param name="base64Str">base64字符串</param>
  //      /// <param name="savePath">图片保存地址，如：/Content/Images/10000.png</param>
  //      /// <returns></returns>
  //      public static bool Base64StrToImage(string base64Str, string savePath)
		//{
  //          var ret = true;
  //          try
  //          {
  //              base64Str = base64Str.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
  //                  .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", ""); //将base64头部信息替换
  //              var bitmap = Base64StrToImage(base64Str );
  //              if (bitmap != null)
  //              {
  //                  //创建文件夹
  //                  var folderPath = savePath.Substring(0, savePath.LastIndexOf('\\'));
  //                  ////FileHelper.CreateDir(folderPath);
  //                  if (!Directory.Exists(folderPath))
  //                  {
  //                      Directory.CreateDirectory(folderPath);
  //                  }
  //                  //图片后缀格式
  //                  var suffix = savePath.Substring(savePath.LastIndexOf('.') + 1,
  //                      savePath.Length - savePath.LastIndexOf('.') - 1).ToLower();
  //                  var suffixName = suffix == "png"
  //                      ? ImageFormat.Png
  //                      : suffix == "jpg" || suffix == "jpeg"
  //                          ? ImageFormat.Jpeg
  //                          : suffix == "bmp"
  //                              ? ImageFormat.Bmp
  //                              : suffix == "gif"
  //                                  ? ImageFormat.Gif
  //                                  : ImageFormat.Jpeg;

  //                  //这里复制一份对图像进行保存，否则会出现“GDI+ 中发生一般性错误”的错误提示
  //                  var bmpNew = new Bitmap(bitmap);
  //                  bmpNew.Save(savePath, suffixName);
  //                  bmpNew.Dispose();
  //                  bitmap.Dispose();
  //              }
  //              else
  //              {
  //                  ret = false;
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              ret = false;
  //          }
  //          return ret;
  //      }




    }
}
