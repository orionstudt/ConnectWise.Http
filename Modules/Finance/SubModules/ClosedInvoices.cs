using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
    public class ClosedInvoicesSubModule : SubModule
    {
        internal ClosedInvoicesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Replace Closed Invoice
        /// </summary>
        /// <param name="invoiceId">The ID of the Invoice to replace.</param>
        /// <param name="serializedClosedInvoice">Serialized ClosedInvoice object to be placed in the body of the request.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ReplaceRequest(int invoiceId, string serializedClosedInvoice)
        {
            return new CWRequest(CWHttpMethod.Put, $"{getPrefix()}/{invoiceId}", serializedClosedInvoice);
        }

        /// <summary>
        /// Update Closed Invoice
        /// </summary>
        /// <param name="invoiceId">The ID of the Invoice to update.</param>
        /// <param name="updates">The list of Patch operations to be applied to the specified Closed Invoice.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest UpdateRequest(int invoiceId, IEnumerable<CWPatch> updates)
        {
            return new CWRequest($"{getPrefix()}/{invoiceId}", updates);
        }
    }
}
