using ConnectWise.Http.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// Main HTTP Client used to interact with ConnectWise Manage API.
    /// </summary>
    public class CWHttpClient : IDisposable
    {
        /// <summary>
        /// Information about your ConnectWise Manage Installation. This is populated the first time you make a request with CWHttpClient.
        /// </summary>
        public CWCompanyInfo Info { get; private set; }

        private readonly string companyName;
        private readonly string clientId;
        private readonly string domain;
        private readonly string cookieValue;
        private readonly string version;
        private readonly string accept;
        //private string accept = "application/vnd.connectwise.com+json; version=3.0.0"; // This accept string was causing bugs on some endpoints
        private readonly AuthenticationHeaderValue auth;
        private readonly HttpClient client;
        private readonly bool ownsClient;

        /// <summary>
        /// HttpClient used to make requests to a ConnectWise Manage API. This constructor will take a pre-instantiated System.Net.Http.HttpClient. Use this if you will be using the provided HttpClient to make requests to other APIs as well, or if you want to set different HttpClient settings. CWHttpClient will not make any changes to your provided HttpClient's default settings.
        /// </summary>
        public CWHttpClient(CWApiSettings settings, HttpClient client = null)
        {
            companyName = settings.CompanyName;
            clientId = settings.ClientId;
            domain = settings.Domain.TrimEnd('/');
            cookieValue = settings.CookieValue;
            version = settings.UriVersion;
            accept = settings.Accept;
            auth = settings.Authentication.BuildHeader(companyName);

            // Passthrough
            if (client != null)
                this.client = client;
            else
            {
                ownsClient = true;
                this.client = new HttpClient();
            }
        }

        /// <summary>
        /// Method used to send a request to the configured Manage API.
        /// </summary>
        /// <param name="request">CWRequest object. Can be pre-build with various included modules or can be constructed manually.</param>
        /// <param name="cts">Cancellation Token Source if you would like to be able to cancel mid-request.</param>
        /// <returns>A generic CWResponse object with no deserialization.</returns>
        public async Task<CWResponse> SendAsync(CWRequest request, CancellationTokenSource cts = null)
        {
            if (cts == null)
                return await SendAsync(request, cancelToken: default).ConfigureAwait(false);

            return await SendAsync(request, cancelToken: cts.Token).ConfigureAwait(false);
        }

        /// <summary>
        /// Method used to send a request to the configured Manage API.
        /// </summary>
        /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
        /// <param name="request">CWRequest object. Can be pre-build with various included modules or can be constructed manually.</param>
        /// <param name="cts">Cancellation Token if you would like to be able to cancel mid-request.</param>
        /// <returns>A CWResponse object that will attempt deserialization to the specified type.</returns>
        public async Task<CWResponse<T>> SendAsync<T>(CWRequest request, CancellationTokenSource cts = null)
            where T : class
        {
            if (cts == null)
                return await SendAsync<T>(request, cancelToken: default).ConfigureAwait(false);

            return await SendAsync<T>(request, cancelToken: cts.Token).ConfigureAwait(false);
        }     

        /// <summary>
        /// Method used to send a request to the configured Manage API.
        /// </summary>
        /// <param name="request">CWRequest object. Can be pre-build with various included modules or can be constructed manually.</param>
        /// <param name="cancelToken">Cancellation Token if you would like to be able to cancel mid-request.</param>
        /// <returns>A generic CWResponse object with no deserialization.</returns>
        public async Task<CWResponse> SendAsync(CWRequest request, CancellationToken cancelToken = default)
        {
            // Check if we have Company Info
            if (Info == null)
            {
                // Need Company Info
                var infoResponse = await getCompanyInfoAsync(cancelToken).ConfigureAwait(false);
                if (!infoResponse.IsSuccessful)
                {
                    return infoResponse;
                }
            }

            // Build Request
            var httpRequest = buildRequest(request);

            // Make Request
            HttpResponseMessage response = null;
            try
            {
                response = await client.SendAsync(httpRequest, cancelToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return new CWResponse("Request cancelled.");
            }
            catch (Exception e)
            {
                return new CWResponse(e.ToString());
            }

            // Check Response
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new CWResponse(response, content);
            }
            return new CWResponse("There was an error making the request to the CW Manage API.");
        }

        /// <summary>
        /// Method used to send a request to the configured Manage API.
        /// </summary>
        /// <typeparam name="T">The deserialization type. Must be a class.</typeparam>
        /// <param name="request">CWRequest object. Can be pre-build with various included modules or can be constructed manually.</param>
        /// <param name="cancelToken">Cancellation Token if you would like to be able to cancel mid-request.</param>
        /// <returns>A CWResponse object that will attempt deserialization to the specified type.</returns>
        public async Task<CWResponse<T>> SendAsync<T>(CWRequest request, CancellationToken cancelToken = default)
            where T : class
        {
            // Check if we have Company Info
            if (Info == null)
            {
                // Need Company Info
                var infoResponse = await getCompanyInfoAsync(cancelToken).ConfigureAwait(false);
                if (!infoResponse.IsSuccessful)
                {
                    return new CWResponse<T>(infoResponse.Response, infoResponse.Result, false);
                }
            }

            // Build Request
            var httpRequest = buildRequest(request);

            // Make Request
            HttpResponseMessage response = null;
            try
            {
                response = await client.SendAsync(httpRequest, cancelToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return new CWResponse<T>("Request cancelled.");
            }
            catch (Exception e)
            {
                return new CWResponse<T>(e.ToString());
            }

            // Check Response
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new CWResponse<T>(response, content);
            }
            return new CWResponse<T>("There was an error making the request to the CW Manage API.");
        }

        private HttpRequestMessage buildRequest(CWRequest request)
        {
            // Build Request
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"{domain}/{Info.Codebase}/apis/{version}/{request.Endpoint}"),
            };
            // Content
            if (request.Content != null) { httpRequest.Content = request.Content; }
            // Headers
            httpRequest.Headers.Clear();
            httpRequest.Headers.TryAddWithoutValidation("Accept", accept);
            httpRequest.Headers.TryAddWithoutValidation("clientId", clientId);
            httpRequest.Headers.Authorization = auth;
            if (!string.IsNullOrWhiteSpace(cookieValue)) { httpRequest.Headers.TryAddWithoutValidation("Cookie", string.Concat("cw-app-id=", cookieValue)); }
            // Method
            switch (request.Method)
            {
                case CWHttpMethod.Post:
                    httpRequest.Method = HttpMethod.Post;
                    break;
                case CWHttpMethod.Put:
                    httpRequest.Method = HttpMethod.Put;
                    break;
                case CWHttpMethod.Patch:
                    httpRequest.Method = new HttpMethod("PATCH");
                    break;
                case CWHttpMethod.Delete:
                    httpRequest.Method = HttpMethod.Delete;
                    break;
                default:
                    httpRequest.Method = HttpMethod.Get;
                    break;
            }
            // Return
            return httpRequest;
        }

        private async Task<CWResponse> getCompanyInfoAsync(CancellationToken cancelToken)
        {
            // Build request
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{domain}/login/companyInfo/{companyName}")
            };
            request.Headers.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Make request
            HttpResponseMessage response = null;
            try
            {
                response = await client.SendAsync(request, cancelToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return new CWResponse("Request cancelled.");
            }
            catch (Exception e)
            {
                return new CWResponse(e.ToString());
            }

            // Check response
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize Company Info
                    
                    Info = JsonConvert.DeserializeObject<CWCompanyInfo>(content, CWJsonSerializer.PrivateSetters);

                    // Return Success
                    return new CWResponse();
                }
                return new CWResponse(response, content);
            }
            return new CWResponse("Unable to pull CW Company Information required to form future CWRequests.");
        }

        public void Dispose()
        {
            if (this.ownsClient)
                this.client?.Dispose();
        }
    }
}
