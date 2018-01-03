using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company.SubModules
{
    public class CompanyPickerItemsSubModule : PartialSubModule
    {
        internal CompanyPickerItemsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Clear All Picker Items By Member
        /// </summary>
        /// <param name="memberId">ID of Member whose picker items will be cleared.</param>
        /// <param name="companyPickerItemType">Type of picker items to be cleared (Company or Vendor).</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ClearRequest(int memberId, string companyPickerItemType)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/clear?member={memberId}&type={companyPickerItemType}");
        }
    }
}
