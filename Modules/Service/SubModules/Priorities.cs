using ConnectWise.Http;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Service.SubModules
{
    public class PrioritiesSubModule : FullSubModule
    {
        internal PrioritiesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// GET Request for the specified Priority's Image
        /// </summary>
        /// <param name="id">Specified Priority ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ImageRequest(int id)
        {
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}/image", getPrefix()));
        }
    }
}
