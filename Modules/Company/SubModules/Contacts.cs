using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company.SubModules
{
    public class ContactsSubModule : FullSubModule
    {
        internal ContactsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Portal Security
        /// </summary>
        /// <param name="contactId">ID of Contact to get Portal Security information for.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest PortalSecurityRequest(int contactId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{contactId}/portalSecurity");
        }

        /// <summary>
        /// Request Password
        /// </summary>
        /// <param name="content">RequestPasswordRequest JSON object that contains email field.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest RequestPasswordRequest(string content)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/requestPassword", content);
        }

        /// <summary>
        /// Validate Portal Credentials
        /// </summary>
        /// <param name="content">ValidatePortalRequest JSON object that contains email and password fields.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ValidatePortalCredentialsRequest(string content)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/validatePortalCredentials", content);
        }

        /// <summary>
        /// Get Contact Image
        /// </summary>
        /// <param name="contactId">ID of Contact whose's image will be returned.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ImageRequest(int contactId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{contactId}/image");
        }
    }
}
