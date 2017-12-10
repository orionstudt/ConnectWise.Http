using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Company
{
    public static class CompanyModule
    {
        private static string module = "company";

        public static FullSubModule AddressFormats = new FullSubModule(module, "addressFormats");

        // Companies

        // CompanyCustomNotes

        public static FullSubModuleChild CompanyGroups = new FullSubModuleChild(module, "companies", "groups");

        public static FullSubModuleChild CompanyManagementSummaryReports = new FullSubModuleChild(module, "companies", "managementSummaryReports");

        public static FullSubModule CompanyNoteTypes = new FullSubModule(module, "noteTypes");

        public static FullSubModuleChild CompanyNotes = new FullSubModuleChild(module, "companies", "notes");

        // CompanyPickerItems

        public static FullSubModuleChild CompanySites = new FullSubModuleChild(module, "companies", "sites");

        public static FullSubModule CompanyStatuses = new FullSubModule(module, "companies/statuses");

        public static FullSubModuleChild CompanyTeams = new FullSubModuleChild(module, "companies", "teams");

        public static FullSubModule CompanyTypes = new FullSubModule(module, "companies/types");

        public static FullSubModule ConfigurationStatuses = new FullSubModule(module, "configurations/statuses");

        public static FullSubModuleGrandChild ConfigurationTypeQuestionValies = new FullSubModuleGrandChild(module, "configurations/types", "questions", "values");

        public static FullSubModuleChild ConfigurationTypeQuestions = new FullSubModuleChild(module, "configurations/types", "questions");

        public static FullSubModule ConfigurationTypes = new FullSubModule(module, "configurations/types");

        public static FullSubModule Configurations = new FullSubModule(module, "configurations");

        public static FullSubModuleChild ContactCommunications = new FullSubModuleChild(module, "contacts", "communications");

        public static FullSubModule ContactDepartments = new FullSubModule(module, "contacts/departments");

        public static FullSubModuleChild ContactGroups = new FullSubModuleChild(module, "contacts", "groups");

        public static FullSubModuleChild ContactNotes = new FullSubModuleChild(module, "contacts", "notes");

        public static FullSubModule ContactRelationships = new FullSubModule(module, "contacts/relationships");

        public static PartialSubModuleChild ContactTracks = new PartialSubModuleChild(module, "contacts", "tracks");

        public static FullSubModule ContactTypes = new FullSubModule(module, "contacts/types");

        // Contacts

        public static FullSubModule Countries = new FullSubModule(module, "countries");

        public static FullSubModuleChild ManagedDevicesIntegrationCrossReferences = new FullSubModuleChild(module, "managedDevicesIntegrations", "crossReferences");

        public static FullSubModuleChild ManagedDevicesIntegrationLogins = new FullSubModuleChild(module, "managedDevicesIntegrations", "logins");

        public static FullSubModuleChild ManagedDevicesIntegrationNotifications = new FullSubModuleChild(module, "managedDevicesIntegrations", "notifications");

        public static FullSubModule ManagedDevicesIntegrations = new FullSubModule(module, "managedDevicesIntegrations");

        public static FullSubModule ManagementBackups = new FullSubModule(module, "managementBackups");

        public static FullSubModule ManagementEmails = new FullSubModule(module, "managementEmails");

        // ManagementExecuteManagedItSyncs

        public static FullSubModuleChild ManagementItSolutionAgreementInterfaceParameters = new FullSubModuleChild(module, "managementItSolutions", "managementProducts");

        public static FullSubModule ManagementItSolutions = new FullSubModule(module, "managementItSolutions");

        // ManagementLogs

        public static FullSubModuleChild ManagementReportNotifications = new FullSubModuleChild(module, "management", "managementReportNotifications");

        public static UpdateSubModule Managements = new UpdateSubModule(module, "management");

        public static FullSubModule MarketDescriptions = new FullSubModule(module, "marketDescriptions");

        public static FullSubModule OwnershipTypes = new FullSubModule(module, "ownershipTypes");

        public static FullSubModule TeamRoles = new FullSubModule(module, "teamRoles");
    }
}
