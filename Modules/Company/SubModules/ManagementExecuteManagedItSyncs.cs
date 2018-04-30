using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company.SubModules
{
    public class ManagementExecuteManagedItSyncsSubModule : SubModule
    {
        internal ManagementExecuteManagedItSyncsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Execute Managed IT Sync
        /// </summary>
        /// <param name="id">CompanyID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateRequest(int id, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            string conditionStr = conditions.ToUriConditions(CWConditionOptions.StandardConditions);
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{id}/executeManagedItSync{conditionStr}");
        }
    }
}
