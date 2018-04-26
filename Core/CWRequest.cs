using Newtonsoft.Json;
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

        /// <summary>
        /// Construct a CWRequest with no body content.
        /// </summary>
        public CWRequest(CWHttpMethod method, string endpoint)
        {
            Method = method;
            Endpoint = endpoint;
        }

        /// <summary>
        /// Construct a CWRequest with serialized string content in the body.
        /// </summary>
        /// <param name="serializedContent">The serialized string result of your content to be sent in the body.</param>
        public CWRequest(CWHttpMethod method, string endpoint, string serializedContent)
        {
            Method = method;
            Endpoint = endpoint;
            Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Construct a CWRequest with string content in the body.
        /// </summary>
        public CWRequest(CWHttpMethod method, string endpoint, StringContent stringContent)
        {
            Method = method;
            Endpoint = endpoint;
            Content = stringContent;
        }

        /// <summary>
        /// Construct a CWRequest with serialized string content in the body. This constructor will attempt to serialize the content for you.
        /// </summary>
        /// <param name="content">The deserialized object to be serialized and sent in the body.</param>
        public CWRequest(CWHttpMethod method, string endpoint, object content)
        {
            Method = method;
            Endpoint = endpoint;
            Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }
    }
}
