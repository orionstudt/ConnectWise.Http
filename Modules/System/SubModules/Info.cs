using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class InfoSubModule : SubModule
    {
        internal InfoSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Infos
        /// </summary>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest()
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}");
        }
    }
}
