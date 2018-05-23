using ConnectWise.Http.Modules.Company.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company
{
    public static readonly class CompanyModule
    {
        private const string module = "company";

        public static readonly FullSubModule AddressFormats = new FullSubModule(module, "addressFormats");

        public static readonly CompaniesSubModule Companies = new CompaniesSubModule(module, "companies");

        public static readonly FullSubModuleChild CompanyCustomNotes = new FullSubModuleChild(module, "companies", "customStatusNotes");

        public static readonly FullSubModuleChild CompanyGroups = new FullSubModuleChild(module, "companies", "groups");

        public static readonly FullSubModuleChild CompanyManagementSummaryReports = new FullSubModuleChild(module, "companies", "managementSummaryReports");

        public static readonly FullSubModule CompanyNoteTypes = new FullSubModule(module, "noteTypes");

        public static readonly FullSubModuleChild CompanyNotes = new FullSubModuleChild(module, "companies", "notes");

        public static readonly CompanyPickerItemsSubModule CompanyPickerItems = new CompanyPickerItemsSubModule(module, "companyPickerItems");

        public static readonly FullSubModuleChild CompanySites = new FullSubModuleChild(module, "companies", "sites");

        public static readonly FullSubModule CompanyStatuses = new FullSubModule(module, "companies/statuses");

        public static readonly FullSubModuleChild CompanyTeams = new FullSubModuleChild(module, "companies", "teams");

        public static readonly FullSubModule CompanyTypes = new FullSubModule(module, "companies/types");

        public static readonly FullSubModule ConfigurationStatuses = new FullSubModule(module, "configurations/statuses");

        public static readonly FullSubModuleGrandChild ConfigurationTypeQuestionValies = new FullSubModuleGrandChild(module, "configurations/types", "questions", "values");

        public static readonly FullSubModuleChild ConfigurationTypeQuestions = new FullSubModuleChild(module, "configurations/types", "questions");

        public static readonly FullSubModule ConfigurationTypes = new FullSubModule(module, "configurations/types");

        public static readonly FullSubModule Configurations = new FullSubModule(module, "configurations");

        public static readonly FullSubModuleChild ContactCommunications = new FullSubModuleChild(module, "contacts", "communications");

        public static readonly FullSubModule ContactDepartments = new FullSubModule(module, "contacts/departments");

        public static readonly FullSubModuleChild ContactGroups = new FullSubModuleChild(module, "contacts", "groups");

        public static readonly FullSubModuleChild ContactNotes = new FullSubModuleChild(module, "contacts", "notes");

        public static readonly FullSubModule ContactRelationships = new FullSubModule(module, "contacts/relationships");

        public static readonly PartialSubModuleChild ContactTracks = new PartialSubModuleChild(module, "contacts", "tracks");

        public static readonly FullSubModule ContactTypes = new FullSubModule(module, "contacts/types");

        public static readonly ContactsSubModule Contacts = new ContactsSubModule(module, "contacts");

        public static readonly FullSubModule Countries = new FullSubModule(module, "countries");

        public static readonly FullSubModuleChild ManagedDevicesIntegrationCrossReferences = new FullSubModuleChild(module, "managedDevicesIntegrations", "crossReferences");

        public static readonly FullSubModuleChild ManagedDevicesIntegrationLogins = new FullSubModuleChild(module, "managedDevicesIntegrations", "logins");

        public static readonly FullSubModuleChild ManagedDevicesIntegrationNotifications = new FullSubModuleChild(module, "managedDevicesIntegrations", "notifications");

        public static readonly FullSubModule ManagedDevicesIntegrations = new FullSubModule(module, "managedDevicesIntegrations");

        public static readonly FullSubModule ManagementBackups = new FullSubModule(module, "managementBackups");

        public static readonly FullSubModule ManagementEmails = new FullSubModule(module, "managementEmails");

        public static readonly ManagementExecuteManagedItSyncsSubModule ManagementExecuteManagedItSyncs = new ManagementExecuteManagedItSyncsSubModule(module, "management");

        public static readonly FullSubModuleChild ManagementItSolutionAgreementInterfaceParameters = new FullSubModuleChild(module, "managementItSolutions", "managementProducts");

        public static readonly FullSubModule ManagementItSolutions = new FullSubModule(module, "managementItSolutions");

        public static readonly ManagementLogsSubModule ManagementLogs = new ManagementLogsSubModule(module, "management");

        public static readonly FullSubModuleChild ManagementReportNotifications = new FullSubModuleChild(module, "management", "managementReportNotifications");

        public static readonly UpdateSubModule Managements = new UpdateSubModule(module, "management");

        public static readonly FullSubModule MarketDescriptions = new FullSubModule(module, "marketDescriptions");

        public static readonly FullSubModule OwnershipTypes = new FullSubModule(module, "ownershipTypes");

        public static readonly FullSubModule TeamRoles = new FullSubModule(module, "teamRoles");
    }
}
