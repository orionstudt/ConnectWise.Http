using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System.SubModules
{
    public class DocumentsSubModule : PartialSubModule
    {
        internal DocumentsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Download Document
        /// </summary>
        /// <param name="documentId">Specified Document Id.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DownloadRequest(int documentId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{documentId}/download");
        }

        /// <summary>
        /// Get Upload Sample Page
        /// </summary>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest UploadSampleRequest()
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/uploadSample");
        }
    }
}
