using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Project.SubModules
{
    public class ProjectContactsSubModule : PartialSubModuleChild
    {
        internal ProjectContactsSubModule(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// This endpoint does not support a COUNT request.
        /// </summary>
        /// <returns>NULL</returns>
        public override CWRequest CountRequest(int id, CWRequestConditions conditions = null)
        {
            return null;
        }
    }
}
