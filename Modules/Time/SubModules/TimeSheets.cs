using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Time.SubModules
{
    public class TimeSheetsSubModule : BaseSubModule
    {
        internal TimeSheetsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Submit Time Sheet.
        /// </summary>
        /// <param name="timeSheetId">The ID of the Time Sheet to be submitted.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest SubmitRequest(int timeSheetId)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{timeSheetId}/submit");
        }

        /// <summary>
        /// Reverse Time Sheet.
        /// </summary>
        /// <param name="timeSheetId">The ID of the Time Sheet to be reversed.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ReverseRequest(int timeSheetId)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{timeSheetId}/reverse");
        }
    }
}
