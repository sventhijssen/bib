using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bib
{
    static class ApiRequest
    {
        public static string Get(string url)
        {
            var request = WebRequest.Create(url);
            string json;
            var response = (HttpWebResponse)request.GetResponse();
            request.ContentType = "application/json; charset=utf-8";
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }
            return json;
        }
    }
}
