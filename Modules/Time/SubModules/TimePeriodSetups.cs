using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Time.SubModules
{
    public class TimePeriodSetupsSubModule : PartialSubModule
    {
        internal TimePeriodSetupsSubModule(string module, string endpoint): base(module, endpoint) { }

        /// <summary>
        /// Get Time Period Setup Defaults.
        /// </summary>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DefaultRequest()
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/default");
        }
    }
}
