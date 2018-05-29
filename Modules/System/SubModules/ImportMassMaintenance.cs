using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class ImportMassMaintenanceSubModule : SubModule
    {
        internal ImportMassMaintenanceSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Delete Import Mass Maintenance by Id
        /// </summary>
        /// <param name="importMassMaintenanceId">Specified Import Mass Maintenance Id.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeleteRequest(int importMassMaintenanceId)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{importMassMaintenanceId}");
        }
    }
}
