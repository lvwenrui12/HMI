using System;
using System.Net;
using System.Text;

namespace hmitype
{
    public static class WebClientString
    {
        public static string Getstring(string add)
        {
            int num = 3;
            string text = "err";
            WebClient webClient = new WebClient();
            while (text == "err" && num > 0)
            {
                try
                {
                    text = Encoding.UTF8.GetString(webClient.DownloadData(add));
                    text = text.Trim();
                }
                catch
                {
                    text = "err";
                }
                num--;
            }
            return text;
        }
    }
}
