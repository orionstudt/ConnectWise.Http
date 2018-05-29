using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class DocumentsSetupSubModule : UpdateSubModule
    {
        internal DocumentsSetupSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// This endpoint does not support a COUNT request.
        /// </summary>
        public override CWRequest CountRequest(CWRequestConditions conditions = null)
        {
            return null;
        }
    }
}
