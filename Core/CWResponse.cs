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
    /// ConnectWise Manage generic API result object. This object assumes you will handle deserialization.
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

        internal CWResponse(string error)
        {
            Result = error;
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

    /// <summary>
    /// ConnectWise Manage generic API result object. This object will attempt to deserialize the result for you.
    /// </summary>
    /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
    public class CWResponse<T> : CWResponse where T : class
    {
        /// <summary>
        /// Indicates whether the result was deserialized successfully.
        /// </summary>
        public bool IsDerialized { get; private set; }

        /// <summary>
        /// The deserialized result data.
        /// </summary>
        public T Data { get; private set; }

        internal CWResponse(string error) : base(error) { }

        internal CWResponse(HttpResponseMessage response, bool attemptDeserialization = true) : base(response)
        {
            if (IsSuccessful && attemptDeserialization)
            {
                try
                {
                    Data = JsonConvert.DeserializeObject<T>(Result);
                    IsDerialized = true;
                }
                catch
                {
                    IsDerialized = false;
                }
            }
        }
    }
}
