using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
    public class AccountingBatchesSubModule : PartialSubModule
    {
        internal AccountingBatchesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Re-Export the payload data from an existing batch.
        /// </summary>
        /// <param name="batchId">The ID of the Batch to Re-Export.</param>
        /// <param name="serializedExportAccountingBatchRequest">Serialized ExportAccountingBatchRequest object to be included in the body of the request.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ExportRequest(int batchId, string serializedExportAccountingBatchRequest)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{batchId}/export", serializedExportAccountingBatchRequest);
        }
    }
}
