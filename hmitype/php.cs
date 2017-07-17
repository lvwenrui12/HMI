using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace hmitype
{
    public static class php
    {
        private static string safestring = "A19M89D";

        public static string Userid = "0";

        public static string Username = "";

        public static string Gettimestamp()
        {
            return php.GethttpBack("http://bbs.tjc1688.com/hmi/ajax.php?do=getTime", "");
        }

        public static string getsafeMD5()
        {
            string text = php.Gettimestamp();
            return string.Concat(new string[]
            {
                "User=",
                php.Username,
                "&sgin=",
                php.Getsigin(text),
                "&timestamp=",
                text
            });
        }

        public static string Getsigin(string timestamp)
        {
            return php.MD5(php.safestring + php.Username + timestamp);
        }

        private static string MD5(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] value = mD.ComputeHash(bytes);
            return BitConverter.ToString(value).Replace("-", "");
        }

        public static string getxiangqingstring(string id)
        {
            string text = php.GethttpBack("http://bbs.tjc1688.com/hmi/ajax.php?do=getFileInfo&" + php.getsafeMD5() + "&id=" + id, "");
            string result;
            if (text == "")
            {
                MessageOpen.Show("获取素材详情str内容失败".Language());
                result = text;
            }
            else
            {
                result = text;
            }
            return result;
        }

        public static JObject getxiangqingjson(string id)
        {
            string text = php.GethttpBack("http://bbs.tjc1688.com/hmi/ajax.php?do=getFileInfo&" + php.getsafeMD5() + "&id=" + id, "");
            JObject jObject = (JObject)JsonConvert.DeserializeObject(text);
            JObject result;
            if (jObject == null || jObject.Count < 1)
            {
                MessageOpen.Show("获取素材详情JObject失败".Language());
                MessageOpen.Show(text);
                result = null;
            }
            else
            {
                result = jObject;
            }
            return result;
        }

        public static JObject getfenlei()
        {
            string value = php.GethttpBack("http://bbs.tjc1688.com/hmi/ajax.php?do=getType", "");
            JObject jObject = (JObject)JsonConvert.DeserializeObject(value);
            JObject result;
            if (jObject == null || jObject.Count < 1)
            {
                MessageOpen.Show("获取素材分类失败".Language());
                result = null;
            }
            else
            {
                result = jObject;
            }
            return result;
        }

        public static string GethttpBack(string add, string post)
        {
            WebClient webClient = new WebClient();
            string result = "";
            try
            {
                if (post != "")
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(post);
                    webClient.Headers.Clear();
                    webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    result = Encoding.UTF8.GetString(webClient.UploadData(add, "POST", bytes));
                }
                else
                {
                    result = Encoding.UTF8.GetString(webClient.DownloadData(add));
                }
            }
            catch
            {
                result = "";
            }
            webClient.Dispose();
            return result;
        }

        public static string Getuserfromhtml(HtmlDocument htmldoc)
        {
            HtmlElementCollection elementsByTagName = htmldoc.GetElementsByTagName("strong");
            string result;
            foreach (HtmlElement htmlElement in elementsByTagName)
            {
                if (htmlElement.OuterHtml.Contains("class=vwmy"))
                {
                    result = htmlElement.OuterText.Trim();
                    return result;
                }
            }
            result = "";
            return result;
        }
    }
}
