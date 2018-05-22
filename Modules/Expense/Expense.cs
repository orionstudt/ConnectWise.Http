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
        private static string module = "expense";

        public static GetSubModule Classifications = new GetSubModule(module, "classifications");

        public static FullSubModule ExpenseEntries = new FullSubModule(module, "entries");

        public static ExpenseReportsSubModule ExpenseReports = new ExpenseReportsSubModule(module, "reports");

        public static GetSubModule ExpenseTypeExternalIntegrationReferences = new GetSubModule(module, "expenseTypeExternalIntegrationReferences");

        public static FullSubModule ExpenseTypes = new FullSubModule(module, "types");

        public static FullSubModule PaymentTypes = new FullSubModule(module, "paymentTypes");
    }
}
