using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class CWRequest
    {
        public CWHttpMethod Method { get; set; }

        public string Endpoint { get; set; }

        public StringContent Content { get; set; }

        public CWRequest()
        {
            Method = CWHttpMethod.Get;
        }

        public CWRequest(CWHttpMethod method, string endpoint)
        {
            Method = method;
            Endpoint = endpoint;
        }

        public CWRequest(CWHttpMethod method, string endpoint, string content)
        {
            Method = method;
            Endpoint = endpoint;
            Content = new StringContent(content, Encoding.UTF8, "application/json");
        }

        public CWRequest(CWHttpMethod method, string endpoint, StringContent content)
        {
            Method = method;
            Endpoint = endpoint;
            Content = content;
        }
    }
}
