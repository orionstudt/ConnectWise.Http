using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class AuthAnvilsSubModule : UpdateSubModule
    {
        internal AuthAnvilsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Validate Auth Anvil URL Connectivity
        /// </summary>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest TestConnectionRequest()
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/testConnection");
        }
    }
}
