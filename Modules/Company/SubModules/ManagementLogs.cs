using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company.SubModules
{
    public class ManagementLogsSubModule : SubModule
    {
        internal ManagementLogsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Management Execute Managed It Syncs
        /// </summary>
        /// <param name="id">CompanyID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(int id, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            string conditionStr = conditions.ToUriConditions(CWConditionOptions.StandardConditions);
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{id}/logs{conditionStr}");
        }

        /// <summary>
        /// Download Document. Testing - seems like there may be an issue with this endpoint?
        /// </summary>
        /// <param name="id">CompanyID.</param>
        /// <param name="filePath"></param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DownloadRequest(int id, string filePath)
        {
            string filePathCondition = !string.IsNullOrWhiteSpace(filePath) ? Uri.EscapeUriString($"?filePath=\"{filePath}\"") : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{id}/logs/download{filePathCondition}");
        }
    }
}
