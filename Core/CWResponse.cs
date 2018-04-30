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
    /// ConnectWise Manage base API result object.
    /// </summary>
    public abstract class CWResponseBase
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

        internal CWResponseBase()
        {
            IsSuccessful = true;
        }

        internal CWResponseBase(string error)
        {
            Result = error;
        }

        internal CWResponseBase(HttpResponseMessage response)
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
    /// ConnectWise Manage generic API result object. This object assumes you will handle deserialization, or trigger it manually.
    /// </summary>
    public class CWResponse : CWResponseBase
    {
        /// <summary>
        /// Deserialize the JSON result into the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
        /// <returns>An instance of the deserialization type.</returns>
        public T Deserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>(Result);
        }

        /// <summary>
        /// If TryDeserialize<T> is attempted and fails the resulting exception will be accessible here.
        /// </summary>
        public Exception DeserializationException { get; private set; }

        /// <summary>
        /// Attempts to deserialize the JSON result into the specified type. Will populate DeserializationException if it fails.
        /// </summary>
        /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
        /// <param name="output">An instance of the deserialization type.</param>
        /// <returns>True if deserialization was successful.</returns>
        public bool TryDeserialize<T>(out T output)
        {
            try
            {
                output = JsonConvert.DeserializeObject<T>(Result);
                return true;
            }
            catch (Exception ex)
            {
                output = default(T);
                DeserializationException = ex;
                return false;
            }
        }

        internal CWResponse() : base() { }

        internal CWResponse(string error) : base(error) { }

        internal CWResponse(HttpResponseMessage response) : base(response) { }
    }

    /// <summary>
    /// ConnectWise Manage generic API result object. This object will attempt to deserialize the result for you.
    /// </summary>
    /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
    public class CWResponse<T> : CWResponseBase where T : class
    {
        /// <summary>
        /// Indicates whether the result was deserialized successfully.
        /// </summary>
        public bool IsDeserialized { get; private set; }

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
                    IsDeserialized = true;
                }
                catch (Exception)
                {
                    IsDeserialized = false;
                    throw;
                }
            }
        }
    }
}
