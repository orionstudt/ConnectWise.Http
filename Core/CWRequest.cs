using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// Send an instance of CWRequest with CWHttpClient to query the configured CW Manage API.
    /// </summary>
    public class CWRequest
    {
        /// <summary>
        /// The HTTP Method of the request. CW needs a custom enumerator for their PATCH Method.
        /// </summary>
        public CWHttpMethod Method { get; set; }

        /// <summary>
        /// The API endpoint substring, including trailing query conditions but excluding a leading forward slash. For "https://cw.siteurl.com/v4_6_release/apis/service/tickets?conditions=status/name%20like%20'%open%'" this would be "service/tickets?conditions=status/name%20like%20'%open%'"
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The content that will be sent in the body of request. This is not always required.
        /// </summary>
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

        /// <summary>
        /// Construct a CWRequest object for a PATCH operation on the specified endpoint.
        /// </summary>
        /// <param name="patchOperations">The enumerable of patch operations to be executed on the specified endpoint.</param>
        public CWRequest(string endpoint, IEnumerable<CWPatch> patchOperations)
        {
            Method = CWHttpMethod.Patch;
            Endpoint = endpoint;
            Content = new StringContent(JsonConvert.SerializeObject(patchOperations.ToList()), Encoding.UTF8, "application/json");
        }
    }
}
