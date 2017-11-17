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

        private string companyName;
        private string domain;
        private string cookieValue;
        private AuthenticationHeaderValue auth;
        private const string version = "3.0";
        private const string accept = "application/vnd.connectwise.com+json; version=3.0.0";
        private HttpClient client;
        private bool hasInternalClient;

        /// <summary>
        /// HttpClient used to make requests to a ConnectWise Manage API.
        /// This constructor will create its own System.Net.Http.HttpClient internally.
        /// </summary>
        public CWHttpClient(CWApiSettings settings)
        {
            // Passthrough
            hasInternalClient = true;
            companyName = settings.CompanyName;
            domain = settings.Domain;
            cookieValue = settings.CookieValue;
            auth = settings.Authentication.BuildHeader(companyName);
        }

        /// <summary>
        /// HttpClient used to make requests to a ConnectWise Manage API.
        /// This constructor will take a pre-instantiated System.Net.Http.HttpClient.
        /// Use this if you will be using the provided HttpClient to make requests to other APIs as well, or if you want to set different HttpClient settings.
        /// CWHttpClient will not make any changes to your provided HttpClient's default settings.
        /// </summary>
        public CWHttpClient(CWApiSettings settings, HttpClient client)
        {
            // Passthrough
            hasInternalClient = false;
            this.client = client;
            companyName = settings.CompanyName;
            domain = settings.Domain;
            cookieValue = settings.CookieValue;
            auth = settings.Authentication.BuildHeader(companyName);
        }

        public async Task<CWResponse> SendAsync(CWRequest request, CancellationTokenSource cts = null)
        {
            // Check if we have Company Info
            if (Info == null)
            {
                // Need Company Info
                var infoResponse = await getCompanyInfo(cts);
                if (!infoResponse.IsSuccessful)
                {
                    return infoResponse;
                }
            }

            // Build Request
            HttpRequestMessage httpRequest;
            switch (request.Method)
            {
                case CWHttpMethod.Post:
                    httpRequest = defaultRequest(request);
                    httpRequest.Method = HttpMethod.Post;
                    break;
                case CWHttpMethod.Put:
                    httpRequest = defaultRequest(request);
                    httpRequest.Method = HttpMethod.Put;
                    break;
                case CWHttpMethod.Patch:
                    httpRequest = defaultRequest(request);
                    httpRequest.Method = new HttpMethod("PATCH");
                    break;
                case CWHttpMethod.Delete:
                    httpRequest = defaultRequest(request);
                    httpRequest.Method = HttpMethod.Delete;
                    break;
                default:
                    httpRequest = defaultRequest(request);
                    httpRequest.Method = HttpMethod.Get;
                    break;
            }

            // Make Request
            HttpResponseMessage response = null;
            try
            {
                if (cts != null) { response = await client.SendAsync(httpRequest, cts.Token); }
                else { response = await client.SendAsync(httpRequest); }
            }
            catch (OperationCanceledException)
            {
                return new CWResponse(false, "Request cancelled.");
            }
            catch (Exception e)
            {
                return new CWResponse(false, e.ToString());
            }

            // Check Response
            if (response != null)
            {
                return new CWResponse(response);
            }
            return new CWResponse(false, "There was an error making the request to the CW Manage API.");
        }

        private HttpRequestMessage defaultRequest(CWRequest request)
        {
            // Build Request
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("{0}/{1}/apis/{2}/{3}", domain, Info.Codebase, version, request.Endpoint)),
            };
            // Content
            if (request.Content != null) { httpRequest.Content = request.Content; }
            // Headers
            httpRequest.Headers.Clear();
            httpRequest.Headers.TryAddWithoutValidation("Accept", accept);
            httpRequest.Headers.Authorization = auth;
            if (!string.IsNullOrWhiteSpace(cookieValue)) { httpRequest.Headers.TryAddWithoutValidation("Cookie", string.Concat("cw-app-id=", cookieValue)); }
            // Return
            return httpRequest;
        }

        private async Task<CWResponse> getCompanyInfo(CancellationTokenSource cts = null)
        {
            // Determine client
            if (client == null) { client = new HttpClient(); }

            // Build request
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Concat(domain.TrimEnd('/'), "/login/companyinfo/", companyName))
            };
            request.Headers.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Make request
            HttpResponseMessage response = null;
            try
            {
                if (cts != null) { response = await client.SendAsync(request, cts.Token); }
                else { response = await client.SendAsync(request); }
            }
            catch (OperationCanceledException)
            {
                return new CWResponse(false, "Request cancelled.");
            }
            catch (Exception e)
            {
                return new CWResponse(false, e.ToString());
            }

            // Check response
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize Company Info
                    var privateSetterSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new PrivateSetterContractResolver()
                    };
                    Info = JsonConvert.DeserializeObject<CWCompanyInfo>(response.Content.ReadAsStringAsync().Result, privateSetterSettings);

                    // Return Success
                    return new CWResponse(true, null);
                }
                return new CWResponse(response);
            }
            return new CWResponse(false, "Unable to pull CW Company Information required to form future CWRequests.");
        }

        public void Dispose()
        {
            if (client != null) { client.Dispose(); }
        }
    }
}
