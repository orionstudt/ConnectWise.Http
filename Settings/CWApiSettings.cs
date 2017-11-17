using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// API Parameters to be used to instantiate CWHttpClient. This only supports Member Authentication (public and private API keys).
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
        /// The Authentication options. Use either CWMemberAuthentication or CWIntegratorLoginAuthentication.
        /// </summary>
        public ICWAuthSettings Authentication { get; set; }

        /// <summary>
        /// If you're cloud hosted, ConnectWise will provide you with a cookie identifier.
        /// </summary>
        public string CookieValue { get; set; }

        /// <param name="domain">The base URL of your ConnectWise Manage installation. Example: https://cw.siteurl.com</param>
        /// <param name="companyName">The 'short' Company Name that you use when you login to ConnectWise Manage.</param>
        /// <param name="publicKey">The public API key - setup with Member Authentication.</param>
        /// <param name="privateKey">The private API key - setup with Member Authentication.</param>
        public CWApiSettings(string domain, string companyName, ICWAuthSettings auth)
        {
            Init(domain, companyName, auth);
        }

        /// <param name="domain">The base URL of your ConnectWise Manage installation. Example: https://cw.siteurl.com</param>
        /// <param name="companyName">The 'short' Company Name that you use when you login to ConnectWise Manage.</param>
        /// <param name="auth">The Authentication options. Use either CWMemberAuthentication or CWIntegratorLoginAuthentication.</param>
        /// <param name="cookieValue">If you're cloud hosted, ConnectWise will provide you with a cookie identifier.</param>
        public CWApiSettings(string domain, string companyName, ICWAuthSettings auth, string cookieValue)
        {
            Init(domain, companyName, auth);
            CookieValue = cookieValue;
        }

        private void Init(string domain, string companyName, ICWAuthSettings auth)
        {
            Domain = domain;
            CompanyName = companyName;
            Authentication = auth;
        }
    }
}
