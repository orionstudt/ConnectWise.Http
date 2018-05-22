using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class MembersSubModule : FullSubModule
    {
        internal MembersSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Member By Member Identifier
        /// </summary>
        /// <param name="memberIdentifier">The specified member's identifier.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(string memberIdentifier, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{memberIdentifier}{conditionStr}");
        }

        /// <summary>
        /// Create Tokens By Member Identifier
        /// </summary>
        /// <param name="memberIdentifier">The specified member's identifier.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateTokensRequest(string memberIdentifier)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{memberIdentifier}/tokens");
        }

        /// <summary>
        /// Create Tokens By Member Id
        /// </summary>
        /// <param name="memberId">The specified member's id.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateTokensRequest(int memberId)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{memberId}/tokens");
        }

        /// <summary>
        /// Deactivate By Member Identifier
        /// </summary>
        /// <param name="memberIdentifier">The specified member's identifier.</param>
        /// <param name="serializedMemberDeactivation">Serialized MemberDeactivation object to be placed in the body of the request.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeactivateRequest(string memberIdentifier, string serializedMemberDeactivation)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{memberIdentifier}/deactivate", serializedMemberDeactivation);
        }

        /// <summary>
        /// Deactivate By Member Id
        /// </summary>
        /// <param name="memberId">The specified member's id.</param>
        /// <param name="serializedMemberDeactivation">Serialized MemberDeactivation object to be placed in the body of the request.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeactivateRequest(int memberId, string serializedMemberDeactivation)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{memberId}/deactivate", serializedMemberDeactivation);
        }
    }
}
