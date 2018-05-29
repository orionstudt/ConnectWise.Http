using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class BatchSubModule : SubModule
    {
        internal BatchSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Process Batch Requests
        /// </summary>
        /// <param name="serializedBody">Serialized BatchRequest object to be sent in the body of the request.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CraeteRequest(string serializedBody)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}", serializedBody);
        }
    }
}
