using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
    public class InvoicePaymentsSubModule : FullSubModuleChild
    {
        internal InvoicePaymentsSubModule(string module, string endpoint, string child) : base(module, endpoint, child) { }

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
