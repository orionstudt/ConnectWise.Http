using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company.SubModules
{
    public class CompaniesSubModule : FullSubModule
    {
        internal CompaniesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Merge Companies
        /// </summary>
        /// <param name="id">CompanyID of Company to merge from.</param>
        /// <param name="content">CompanyMerge JSON body detailing the handling of the merger.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest MergeRequest(int id, string content)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{id}/merge", content);
        }
    }
}
