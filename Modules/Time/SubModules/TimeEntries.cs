using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Time.SubModules
{
    public class TimeEntriesSubModule : FullSubModule
    {
        internal TimeEntriesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Time Entry Defaults
        /// </summary>
        /// <param name="content">Serialized Time Entry content.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DefaultsRequest(string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/defaults{conditionStr}", content);
        }
    }
}
