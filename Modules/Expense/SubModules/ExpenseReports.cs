using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Expense.SubModules
{
    public class ExpenseReportsSubModule : BaseSubModule
    {
        internal ExpenseReportsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Submit Expense Report
        /// </summary>
        /// <param name="id">The ID of the expense report to be submitted.</param>
        /// <returns>CWRequest object to be sent using CWHttpClient.</returns>
        public CWRequest SubmitRequest(int id)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{id}/submit");
        }

        /// <summary>
        /// Reverse Expense Report
        /// </summary>
        /// <param name="id">The ID of the expense report to be reversed.</param>
        /// <returns>CWRequest object to be sent using CWHttpClient.</returns>
        public CWRequest ReverseRequest(int id)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{id}/reverse");
        }
    }
}
