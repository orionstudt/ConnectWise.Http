using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// API Parameters to be used to instantiate CWHttpClient.
    /// </summary>
    public class CWApiSettings
    {
        /// <summary>
        /// The base URL of your ConnectWise Manage installation. Example: https://cw.siteurl.com
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The 'short' Company Name that you use when you login to ConnectWise Manage.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The Authentication options. Use IntegratorAuthSettings, MemberAuthSettings, or implement your own with IAuthSettings.
        /// </summary>
        public IAuthSettings Authentication { get; set; }

        /// <summary>
        /// The version that appears in the Uri string. Defaults to '3.0'. Example: https://cw.siteurl.com/v4_6_release/apis/3.0/module/endpoint
        /// </summary>
        public string UriVersion { get; set; }

        /// <summary>
        /// The Accept Header that will be send with each request. Defaulting to 'application/json'. Their 'application/vnd.connectwise.com+json; version=3.0.0' Accept value was causing issues but you can set that here if you would like.
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// If you're cloud hosted, ConnectWise will provide you with a cookie identifier.
        /// </summary>
        public string CookieValue { get; set; }

        /// <param name="domain">The base URL of your ConnectWise Manage installation. Example: https://cw.siteurl.com</param>
        /// <param name="companyName">The 'short' Company Name that you use when you login to ConnectWise Manage.</param>
        /// <param name="publicKey">The public API key - setup with Member Authentication.</param>
        /// <param name="privateKey">The private API key - setup with Member Authentication.</param>
        /// <param name="uriVersion">The version that appears in the Uri.</param>
        /// <param name="accept">The Accept Header value.</param>
        public CWApiSettings(string domain, string companyName, IAuthSettings auth, string uriVersion = "3.0", string accept = "application/json")
        {
            init(domain, companyName, auth, uriVersion, accept);
        }

        /// <param name="domain">The base URL of your ConnectWise Manage installation. Example: https://cw.siteurl.com</param>
        /// <param name="companyName">The 'short' Company Name that you use when you login to ConnectWise Manage.</param>
        /// <param name="auth">The Authentication options. Use either CWMemberAuthentication or CWIntegratorLoginAuthentication.</param>
        /// <param name="cookieValue">If you're cloud hosted, ConnectWise will provide you with a cookie identifier.</param>
        /// <param name="uriVersion">The version that appears in the Uri.</param>
        /// <param name="accept">The Accept Header value.</param>
        public CWApiSettings(string domain, string companyName, IAuthSettings auth, string cookieValue, string uriVersion = "3.0", string accept = "application/json")
        {
            init(domain, companyName, auth, uriVersion, accept);
            CookieValue = cookieValue;
        }

        private void init(string domain, string companyName, IAuthSettings auth, string uriVersion, string accept)
        {
            Domain = domain;
            CompanyName = companyName;
            Authentication = auth;
            UriVersion = uriVersion;
            Accept = accept;
        }
    }
}
