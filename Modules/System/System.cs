using ConnectWise.Http.Modules.System.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System
{
    public static class SystemModule
    {
        private const string module = "system";

        public static readonly BaseSubModule AuditTrail = new BaseSubModule(module, "auditTrail");

        public static readonly AuthAnvilsSubModule AuthAnvils = new AuthAnvilsSubModule(module, "authAnvils");

        public static readonly BatchSubModule Batch = new BatchSubModule(module, "batch");

        public static readonly FullSubModule Callbacks = new FullSubModule(module, "callbacks");

        public static readonly FullSubModule Certifications = new FullSubModule(module, "certifications");

        public static readonly FullSubModule ConnectWiseHostedSetups = new FullSubModule(module, "connectWiseHostedSetups");

        public static readonly GetSubModule CorporateStructureLebels = new GetSubModule(module, "myCompany/corporateStructureLevels");

        public static readonly UpdateSubModule CorporateStructures = new UpdateSubModule(module, "myCompany/corporateStructure");

        public static readonly UpdateSubModule Crms = new UpdateSubModule(module, "myCompany/crm");

        public static readonly FullSubModuleChild CustomReportParameters = new FullSubModuleChild(module, "customReports", "parameters");

        public static readonly FullSubModule CustomReports = new FullSubModule(module, "customReports");

        public static readonly FullSubModuleChild DepartmentLocations = new FullSubModuleChild(module, "departments", "locations");

        public static readonly FullSubModule Departments = new FullSubModule(module, "departments");

        public static readonly DocumentsSubModule Documents = new DocumentsSubModule(module, "documents");

        public static readonly DocumentsSetupSubModule DocumentsSetup = new DocumentsSetupSubModule(module, "mycompany/documents");

        public static readonly FullSubModule EPayConfigurations = new FullSubModule(module, "ePayConfigurations");

        public static readonly FullSubModuleGrandChild EmailConnectorParsingRules = new FullSubModuleGrandChild(module, "emailConnectors", "parsingStyles", "parsingRules");

        public static readonly FullSubModuleChild EmailConnectorParsingStyles = new FullSubModuleChild(module, "emailConnectors", "parsingStyles");

        public static readonly FullSubModule EmailConnectors = new FullSubModule(module, "emailConnectors");

        public static readonly GetSubModule EmailTokens = new GetSubModule(module, "emailTokens");

        public static readonly FullSubModule IMaps = new FullSubModule(module, "imaps");

        public static readonly ImportMassMaintenanceSubModule ImportsMassMaintenance = new ImportMassMaintenanceSubModule(module, "importMassMaintenance");

        public static readonly FullSubModule InOutBoards = new FullSubModule(module, "inOutBoards");

        public static readonly FullSubModule InOutTypes = new FullSubModule(module, "inOutTypes");

        public static readonly InfoSubModule Info = new InfoSubModule(module, "info");

        public static readonly FullSubModule IntegratorLogins = new FullSubModule(module, "integratorLogins");

        public static readonly GetSubModule KPICategories = new GetSubModule(module, "kpiCategories");

        public static readonly GetSubModule KPIs = new GetSubModule(module, "kpis");

        public static readonly GetSubModule Labs = new GetSubModule(module, "labs");

        public static readonly FullSubModule LdapConfigurations = new FullSubModule(module, "ldapConfigurations");

        public static readonly FullSubModule Links = new FullSubModule(module, "links");

        public static readonly GetSubModuleChild LocationDepartments = new GetSubModuleChild(module, "locations", "departments");

        public static readonly GetSubModuleChild LocationWorkRoles = new GetSubModuleChild(module, "locations", "workRoles");

        public static readonly FullSubModule Locations = new FullSubModule(module, "locations");

        public static readonly ManagementNetworkSecuritiesSubModule ManagementNetworksSecurity = new ManagementNetworkSecuritiesSubModule(module, "managementNetworkSecurities");

        public static readonly FullSubModuleChild MemberAccruals = new FullSubModuleChild(module, "members", "accruals");

        public static readonly FullSubModuleChild MemberCertifications = new FullSubModuleChild(module, "members", "certifications");

        public static readonly FullSubModuleChild MemberDelegations = new FullSubModuleChild(module, "members", "delegations");

        public static readonly FullSubModuleChild MemberSkills = new FullSubModuleChild(module, "members", "skills");

        public static readonly FullSubModule MemberTypes = new FullSubModule(module, "members/types");

        public static readonly MembersSubModule Members = new MembersSubModule(module, "members");

        // MenuEntries

        public static readonly PartialSubModuleChild MenuEntryLocations = new PartialSubModuleChild(module, "menuEntries", "locations");

        public static readonly FullSubModuleChild MyMemberCertifications = new FullSubModuleChild(module, "members", "myCertifications");

        // MyMembers

        // MySecuritys

        public static readonly GetSubModule NotificationRecipients = new GetSubModule(module, "notificationRecipients");

        public static readonly UpdateSubModule Others = new UpdateSubModule(module, "myCompany/other");

        public static readonly GetSubModule ParsingTypes = new GetSubModule(module, "parsingTypes");

        public static readonly GetSubModule ParsingVariables = new GetSubModule(module, "parsingVariables");

        public static readonly FullSubModule PortalReports = new FullSubModule(module, "portalReports");

        public static readonly FullSubModuleChild ReportCardDetails = new FullSubModuleChild(module, "reportCards", "details");

        public static readonly FullSubModule ReportCards = new FullSubModule(module, "reportCards");

        // ReportingServices

        // Reports

        public static readonly GetSubModuleChild SecurityRoleSettings = new GetSubModuleChild(module, "securityRoles", "settings");

        public static readonly PartialSubModule SecurityRoles = new PartialSubModule(module, "securityRoles");

        // Services

        public static readonly GetSubModule SetupScreens = new GetSubModule(module, "setupScreens");

        public static readonly FullSubModule SkillCategories = new FullSubModule(module, "skillCategories");

        public static readonly FullSubModule Skills = new FullSubModule(module, "skills");

        // SurveyQuestionValues

        // SurveyQuestions

        // Surveys

        public static readonly UpdateSubModule TimeExpenses = new UpdateSubModule(module, "myCompany/timeExpense");

        public static readonly FullSubModule TimeZoneSetups = new FullSubModule(module, "timeZoneSetups");

        public static readonly GetSubModule TimeZones = new GetSubModule(module, "timeZones");

        public static readonly FullSubModule TodayPageCategories = new FullSubModule(module, "todayPageCategorise");

        public static readonly FullSubModule UserDefinedFields = new FullSubModule(module, "userDefinedFields");

        public static readonly FullSubModuleChild WorkflowActionAutomateParameters = new FullSubModuleChild(module, "workflowActions", "automateParameters");

        public static readonly FullSubModuleGrandChild WorkflowActions = new FullSubModuleGrandChild(module, "workflows", "events", "actions");

        public static readonly GetSubModuleChild WorkflowAttachments = new GetSubModuleChild(module, "workflows", "attachments");

        // WorkflowEvents

        public static readonly GetSubModuleChild WorkflowNotifyTypes = new GetSubModuleChild(module, "workflows", "notifyTypes");

        public static readonly GetSubModule WorkflowTableTypes = new GetSubModule(module, "workflows/tableTypes");

        public static readonly BaseSubModuleGrandChild WorkflowTriggerOptions = new BaseSubModuleGrandChild(module, "workflows", "triggers", "options");

        public static readonly BaseSubModuleChild WorkflowTriggers = new BaseSubModuleChild(module, "workflows", "triggers");

        // Workflows
    }
}
