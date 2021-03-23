using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace DWM
{
    internal class Http
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient())
                return webClient.UploadValues(uri, pairs);
        }
    }
}