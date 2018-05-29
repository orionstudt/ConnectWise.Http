using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class ManagementNetworkSecuritiesSubModule : FullSubModule
    {
        internal ManagementNetworkSecuritiesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Test Credentials *Needs to be tested as documentation is incomplete*
        /// </summary>
        /// <param name="credentialsId">Specified Credentials Id</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest TestCredentialsRequest(int credentialsId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/testCredentials", credentialsId.ToString());
        }
    }
}
