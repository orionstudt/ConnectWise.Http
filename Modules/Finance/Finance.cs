using ConnectWise.Http.Modules.Finance.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Finance
{
    public static class FinanceModule
    {
        private static string module = "finance";

        public static AccountingBatchesSubModule AccountingBatches = new AccountingBatchesSubModule(module, "accounting/batches");

        public static GetSubModule AccountingPackages = new GetSubModule(module, "accountingPackages");

        public static GetSubModule AccountingUnpostedExpenses = new GetSubModule(module, "accounting/unpostedexpenses");

        public static GetSubModule AccountingUnpostedProcurements = new GetSubModule(module, "accounting/unpostedprocurement");

        public static GetSubModule AccountingUnpostedInvoices = new GetSubModule(module, "accounting/unpostedinvoices");

        public static FullSubModuleChild AgreementAdditions = new FullSubModuleChild(module, "agreements", "additions");

        public static FullSubModuleChild AgreementAdjustments = new FullSubModuleChild(module, "agreements", "adjustments");

        public static UpdateSubModule AgreementBatchSetups = new UpdateSubModule(module, "batchSetups");

        public static FullSubModuleChild AgreementBoardDefaults = new FullSubModuleChild(module, "agreements", "boardDefaults");

        public static PartialSubModuleChild AgreementConfigurations = new PartialSubModuleChild(module, "agreements", "configurations");

        public static FullSubModuleChild AgreementSites = new FullSubModuleChild(module, "agreements", "sites");

        public static FullSubModuleChild AgreementTypeBoardDefaults = new FullSubModuleChild(module, "agreementTypes", "boardDefaults");

        public static PartialSubModuleChild AgreementTypeWorkRoleExclusions = new PartialSubModuleChild(module, "agreementTypes", "workRoleExclusions");

        public static FullSubModuleChild AgreementTypeWorkRoles = new FullSubModuleChild(module, "agreementTypes", "workRoles");

        public static PartialSubModuleChild AgreementTypeWorkTypeExclusions = new PartialSubModuleChild(module, "agreementTypes", "workTypeExclusions");

        public static FullSubModuleChild AgreementTypeWorkTypes = new FullSubModuleChild(module, "agreementTypes", "workTypes");

        public static FullSubModule AgreementTypes = new FullSubModule(module, "agreements/types");

        public static PartialDeleteSubModuleChild AgreementWorkRoleExclusions = new PartialDeleteSubModuleChild(module, "agreements", "workRoleExclusions");

        public static FullSubModuleChild AgreementWorkRoles = new FullSubModuleChild(module, "agreements", "workRoles");

        public static PartialDeleteSubModuleChild AgreementWorkTypeExclusions = new PartialDeleteSubModuleChild(module, "agreements", "workTypeExclusions");

        public static FullSubModuleChild AgreementWorkTypes = new FullSubModuleChild(module, "agreements", "workTypes");

        public static FullSubModule Agreements = new FullSubModule(module, "agreements");

        public static FullSubModule BillingCycles = new FullSubModule(module, "billingCycles");

        public static FullSubModuleChild BillingSetupRoutings = new FullSubModuleChild(module, "billingSetups", "routings");

        public static FullSubModule BillingSetups = new FullSubModule(module, "billingSetups");

        public static GetSubModule BillingStatuses = new GetSubModule(module, "billingStatuses");

        public static FullSubModule BillingTerms = new FullSubModule(module, "billingTerms");

        public static ClosedInvoicesSubModule ClosedInvoices = new ClosedInvoicesSubModule(module, "closedInvoices");

        public static FullSubModule Currencies = new FullSubModule(module, "currencies");

        public static FullSubModule DeliveryMethods = new FullSubModule(module, "deliveryMethods");

        public static FullSubModule InvoiceEmailTemplates = new FullSubModule(module, "invoiceEmailTemplates");

        public static InvoicePaymentsSubModule InvoicePayments = new InvoicePaymentsSubModule(module, "invoices", "payments");

        public static GetSubModule InvoiceTemplateSetups = new GetSubModule(module, "invoiceTemplateSetups");

        public static GetSubModule InvoiceTemplates = new GetSubModule(module, "invoiceTemplates");

        public static InvoicesSubModule Invoices = new InvoicesSubModule(module, "invoices");

        public static FullSubModuleChild TaxCodeExpenseTypeExemptions = new FullSubModuleChild(module, "taxCodes", "expenseTypeExemptions");

        public static FullSubModuleChild TaxCodeProductTypeExemptions = new FullSubModuleChild(module, "taxCodes", "productTypeExemptions");

        public static FullSubModuleChild TaxCodeWorkRoleExemptions = new FullSubModuleChild(module, "taxCodes", "workRoleExemptions");

        public static FullSubModuleChild TaxCodeXRefs = new FullSubModuleChild(module, "taxCodes", "taxCodeXRefs");

        public static FullSubModule TaxCodes = new FullSubModule(module, "taxCodes");

        public static GetSubModule TaxIntegrations = new GetSubModule(module, "taxIntegrations");
    }
}
