using ConnectWise.Http.Modules.Expense.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Expense
{
    public static class ExpenseModule
    {
        private const string module = "expense";

        public static readonly GetSubModule Classifications = new GetSubModule(module, "classifications");

        public static readonly FullSubModule ExpenseEntries = new FullSubModule(module, "entries");

        public static readonly ExpenseReportsSubModule ExpenseReports = new ExpenseReportsSubModule(module, "reports");

        public static readonly GetSubModule ExpenseTypeExternalIntegrationReferences = new GetSubModule(module, "expenseTypeExternalIntegrationReferences");

        public static readonly FullSubModule ExpenseTypes = new FullSubModule(module, "types");

        public static readonly FullSubModule PaymentTypes = new FullSubModule(module, "paymentTypes");
    }
}
