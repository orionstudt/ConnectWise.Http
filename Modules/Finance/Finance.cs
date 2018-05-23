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
        private const string module = "finance";

        public static readonly AccountingBatchesSubModule AccountingBatches = new AccountingBatchesSubModule(module, "accounting/batches");

        public static readonly GetSubModule AccountingPackages = new GetSubModule(module, "accountingPackages");

        public static readonly GetSubModule AccountingUnpostedExpenses = new GetSubModule(module, "accounting/unpostedexpenses");

        public static readonly GetSubModule AccountingUnpostedProcurements = new GetSubModule(module, "accounting/unpostedprocurement");

        public static readonly GetSubModule AccountingUnpostedInvoices = new GetSubModule(module, "accounting/unpostedinvoices");

        public static readonly FullSubModuleChild AgreementAdditions = new FullSubModuleChild(module, "agreements", "additions");

        public static readonly FullSubModuleChild AgreementAdjustments = new FullSubModuleChild(module, "agreements", "adjustments");

        public static readonly UpdateSubModule AgreementBatchSetups = new UpdateSubModule(module, "batchSetups");

        public static readonly FullSubModuleChild AgreementBoardDefaults = new FullSubModuleChild(module, "agreements", "boardDefaults");

        public static readonly PartialSubModuleChild AgreementConfigurations = new PartialSubModuleChild(module, "agreements", "configurations");

        public static readonly FullSubModuleChild AgreementSites = new FullSubModuleChild(module, "agreements", "sites");

        public static readonly FullSubModuleChild AgreementTypeBoardDefaults = new FullSubModuleChild(module, "agreementTypes", "boardDefaults");

        public static readonly PartialSubModuleChild AgreementTypeWorkRoleExclusions = new PartialSubModuleChild(module, "agreementTypes", "workRoleExclusions");

        public static readonly FullSubModuleChild AgreementTypeWorkRoles = new FullSubModuleChild(module, "agreementTypes", "workRoles");

        public static readonly PartialSubModuleChild AgreementTypeWorkTypeExclusions = new PartialSubModuleChild(module, "agreementTypes", "workTypeExclusions");

        public static readonly FullSubModuleChild AgreementTypeWorkTypes = new FullSubModuleChild(module, "agreementTypes", "workTypes");

        public static readonly FullSubModule AgreementTypes = new FullSubModule(module, "agreements/types");

        public static readonly PartialDeleteSubModuleChild AgreementWorkRoleExclusions = new PartialDeleteSubModuleChild(module, "agreements", "workRoleExclusions");

        public static readonly FullSubModuleChild AgreementWorkRoles = new FullSubModuleChild(module, "agreements", "workRoles");

        public static readonly PartialDeleteSubModuleChild AgreementWorkTypeExclusions = new PartialDeleteSubModuleChild(module, "agreements", "workTypeExclusions");

        public static readonly FullSubModuleChild AgreementWorkTypes = new FullSubModuleChild(module, "agreements", "workTypes");

        public static readonly FullSubModule Agreements = new FullSubModule(module, "agreements");

        public static readonly FullSubModule BillingCycles = new FullSubModule(module, "billingCycles");

        public static readonly FullSubModuleChild BillingSetupRoutings = new FullSubModuleChild(module, "billingSetups", "routings");

        public static readonly FullSubModule BillingSetups = new FullSubModule(module, "billingSetups");

        public static readonly GetSubModule BillingStatuses = new GetSubModule(module, "billingStatuses");

        public static readonly FullSubModule BillingTerms = new FullSubModule(module, "billingTerms");

        public static readonly ClosedInvoicesSubModule ClosedInvoices = new ClosedInvoicesSubModule(module, "closedInvoices");

        public static readonly FullSubModule Currencies = new FullSubModule(module, "currencies");

        public static readonly FullSubModule DeliveryMethods = new FullSubModule(module, "deliveryMethods");

        public static readonly FullSubModule InvoiceEmailTemplates = new FullSubModule(module, "invoiceEmailTemplates");

        public static readonly InvoicePaymentsSubModule InvoicePayments = new InvoicePaymentsSubModule(module, "invoices", "payments");

        public static readonly GetSubModule InvoiceTemplateSetups = new GetSubModule(module, "invoiceTemplateSetups");

        public static readonly GetSubModule InvoiceTemplates = new GetSubModule(module, "invoiceTemplates");

        public static readonly InvoicesSubModule Invoices = new InvoicesSubModule(module, "invoices");

        public static readonly FullSubModuleChild TaxCodeExpenseTypeExemptions = new FullSubModuleChild(module, "taxCodes", "expenseTypeExemptions");

        public static readonly FullSubModuleChild TaxCodeProductTypeExemptions = new FullSubModuleChild(module, "taxCodes", "productTypeExemptions");

        public static readonly FullSubModuleChild TaxCodeWorkRoleExemptions = new FullSubModuleChild(module, "taxCodes", "workRoleExemptions");

        public static readonly FullSubModuleChild TaxCodeXRefs = new FullSubModuleChild(module, "taxCodes", "taxCodeXRefs");

        public static readonly FullSubModule TaxCodes = new FullSubModule(module, "taxCodes");

        public static readonly GetSubModule TaxIntegrations = new GetSubModule(module, "taxIntegrations");
    }
}
