using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Marketing.SubModules
{
    public class CampaignsSubModule : FullSubModule
    {
        internal CampaignsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Campaign Activities
        /// </summary>
        /// <param name="campaignId">Specified Campaign ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetActivitiesRequest(int campaignId, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.Pagination) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{campaignId}/activities{conditionStr}");
        }

        /// <summary>
        /// Get Campaign Activities Count
        /// </summary>
        /// <param name="campaignId">Specified Campaign ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CountActivitiesRequest(int campaignId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{campaignId}/activities/count");
        }

        /// <summary>
        /// Get Campaign Opportunities
        /// </summary>
        /// <param name="campaignId">Specified Campaign ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetOpportunitiesRequest(int campaignId, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.Pagination) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{campaignId}/opportunities{conditionStr}");
        }

        /// <summary>
        /// Get Campaign Opportunities Count
        /// </summary>
        /// <param name="campaignId">Specified Campaign ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CountOpportunitiesRequest(int campaignId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{campaignId}/opportunities/count");
        }
    }
}
