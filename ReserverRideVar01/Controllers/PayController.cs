using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class PayController : Controller
    {
        string hashKey = "OLkdjTkzOoNYjDmeFmCk7CORlRTo4F47";
        string hashIV = "CHsEQUu2AbRqDtQP";
        [HttpGet]
        public IActionResult Pay(decimal payment)
        {
            
                string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string orderNo = "Ezpay" + new Random().Next(0, 99999).ToString();
                string info = $"MerchantID=PG100000008080&TimeStamp={dateTime}&Version=1.0&MerchantOrderNo={orderNo}&Amt={payment}&ItemDesc=test";
                Console.WriteLine(EncryptAES256(info, hashKey, hashIV));
                string aes = EncryptAES256(info, hashKey, hashIV);
                Console.WriteLine(getHashSha256($"HashKey={hashKey}&{aes}&HashIV={hashIV}"));
                string sha = getHashSha256($"HashKey={hashKey}&{aes}&HashIV={hashIV}");
                
                ViewBag.MerchantID = "PG100000008080";
                ViewBag.Version = "1.0";
                ViewBag.TradeInfo = aes;
                ViewBag.TradeSha = sha;
                ViewBag.TimeStamp = dateTime;
                ViewBag.MerchantOrderNo = orderNo;
                ViewBag.Amt = payment;
                ViewBag.ItemDesc = "test";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("MerchantID", "PG100000008080");
                parameters.Add("Version", "1.0");
                parameters.Add("TradeInfo", aes);
                parameters.Add("TradeSha", sha);
                parameters.Add("TimeStamp", dateTime);
                parameters.Add("MerchantOrderNo", orderNo);
                parameters.Add("Amt", payment);
                parameters.Add("ItemDesc", "test");

                List<KeyValuePair<string, object>> parametersList = parameters.ToList();
                parametersList = parametersList.OrderBy(x => x.Key).ToList();
                return View(parametersList);
        }
        public ActionResult EzPayReturn()
        {
            var status = Request.Form["Status"];
            var MerchantID = Request.Form["MerchantID"];
            var TradeInfo = Request.Form["TradeInfo"];
            var TradeSha = Request.Form["TradeSha"];
            string aes = DecryptAES256(TradeInfo);
            //string TradeNo = aes[];
            return Content(string.Empty);
        }

        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }

        public static string EncryptAES256(string source, string hashKey, string hashIV)//加密
        {
            string sSecretKey = hashKey;
            string iv = hashIV;
            byte[] sourceBytes = AddPKCS7Padding(Encoding.UTF8.GetBytes(source), 32);
            var aes = new RijndaelManaged();
            aes.Key = Encoding.UTF8.GetBytes(sSecretKey);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            ICryptoTransform transform = aes.CreateEncryptor();
            return ByteArrayToHex(transform.TransformFinalBlock(sourceBytes, 0,
           sourceBytes.Length)).ToLower();
        }

        public string DecryptAES256(string encryptData)//解密
        {
            string sSecretKey = hashKey;
            string iv = hashIV;
            var encryptBytes = HexStringToByteArray(encryptData.ToUpper());
            var aes = new RijndaelManaged();
            aes.Key = Encoding.UTF8.GetBytes(sSecretKey);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            ICryptoTransform transform = aes.CreateDecryptor();
            return
            Encoding.UTF8.GetString(RemovePKCS7Padding(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length)));
        }


        private static byte[] AddPKCS7Padding(byte[] data, int iBlockSize)
        {
            int iLength = data.Length;
            byte cPadding = (byte)(iBlockSize - (iLength % iBlockSize));
            var output = new byte[iLength + cPadding];
            Buffer.BlockCopy(data, 0, output, 0, iLength);
            for (var i = iLength; i < output.Length; i++)
                output[i] = (byte)cPadding;
            return output;
        }

        private static string ByteArrayToHex(byte[] barray)
        {
            char[] c = new char[barray.Length * 2];
            byte b;
            for (int i = 0; i < barray.Length; ++i)
            {
                b = ((byte)(barray[i] >> 4));
                c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(barray[i] & 0xF));
                c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }

        private static byte[] RemovePKCS7Padding(byte[] data)
        {
            int iLength = data[data.Length - 1];
            var output = new byte[data.Length - iLength];
            Buffer.BlockCopy(data, 0, output, 0, output.Length);
            return output;
        }
        private static byte[] HexStringToByteArray(string hexString)
        {
            int hexStringLength = hexString.Length;
            byte[] b = new byte[hexStringLength / 2];
            for (int i = 0; i < hexStringLength; i += 2)
            {
                int topChar = (hexString[i] > 0x40 ? hexString[i] - 0x37 : hexString[i] - 0x30) << 4;
                int bottomChar = hexString[i + 1] > 0x40 ? hexString[i + 1] - 0x37 : hexString[i + 1] - 0x30;
                b[i / 2] = Convert.ToByte(topChar + bottomChar);
            }
            return b;
        }

    }
}
