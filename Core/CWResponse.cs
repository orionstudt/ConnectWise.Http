using ConnectWise.Http.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// ConnectWise Manage generic API result object.
    /// </summary>
    public class CWResponse
    {
        /// <summary>
        /// Indicates whether the query was successful.
        /// </summary>
        public bool IsSuccessful { get; private set; }

        /// <summary>
        /// The raw string result from the API, to be deserialized.
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// The deserialized error result from the API. If this fails to deserialize the raw response will be in Result.
        /// </summary>
        public CWErrorResult Error { get; private set; }

        /// <summary>
        /// The HttpResponseMessage returned by the HttpClient.
        /// </summary>
        public HttpResponseMessage Response { get; private set; }

        internal CWResponse()
        {
            IsSuccessful = true;
        }

        internal CWResponse(string result)
        {
            Result = result;
        }

        internal CWResponse(HttpResponseMessage response)
        {
            IsSuccessful = response.IsSuccessStatusCode;
            Result = response.Content.ReadAsStringAsync().Result;
            Response = response;
            if (!IsSuccessful)
            {
                var privateSetterSettings = new JsonSerializerSettings
                {
                    ContractResolver = new PrivateSetterContractResolver()
                };
                try
                {
                    Error = JsonConvert.DeserializeObject<CWErrorResult>(Result, privateSetterSettings);
                }
                catch (Exception e)
                {
                    Error = new CWErrorResult("Error deserializing CWHttpClient error response. View the raw string result of the error in the Result property.", $"Exception: {e.ToString()}");
                }
            }
        }
    }
}
