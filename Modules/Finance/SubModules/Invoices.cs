using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
    public class InvoicesSubModule : FullSubModule
    {
        internal InvoicesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Invoice PDF
        /// </summary>
        /// <param name="invoiceId">The ID of the Invoice to be requested as a PDF.</param>
        /// <returns>CWRequest object to be sent using CWHttpClient.</returns>
        public CWRequest PdfRequest(int invoiceId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{invoiceId}/pdf");
        }
    }
}
