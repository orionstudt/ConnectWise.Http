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
        private static string module = "system";

        public static BaseSubModule AuditTrail = new BaseSubModule(module, "auditTrail");

        // AuthAnvils

        // Batch

        public static FullSubModule Callbacks = new FullSubModule(module, "callbacks");

        public static FullSubModule Certifications = new FullSubModule(module, "certifications");

        public static FullSubModule ConnectWiseHostedSetups = new FullSubModule(module, "connectWiseHostedSetups");

        public static GetSubModule CorporateStructureLebels = new GetSubModule(module, "myCompany/corporateStructureLevels");

        public static UpdateSubModule CorporateStructures = new UpdateSubModule(module, "myCompany/corporateStructure");

        public static UpdateSubModule Crms = new UpdateSubModule(module, "myCompany/crm");

        public static FullSubModuleChild CustomReportParameters = new FullSubModuleChild(module, "customReports", "parameters");

        public static FullSubModule CustomReports = new FullSubModule(module, "customReports");

        public static FullSubModuleChild DepartmentLocations = new FullSubModuleChild(module, "departments", "locations");

        public static FullSubModule Departments = new FullSubModule(module, "departments");

        // Documents

        // DocumentsSetup

        public static FullSubModule EPayConfigurations = new FullSubModule(module, "ePayConfigurations");

        public static FullSubModuleGrandChild EmailConnectorParsingRules = new FullSubModuleGrandChild(module, "emailConnectors", "parsingStyles", "parsingRules");

        public static FullSubModuleChild EmailConnectorParsingStyles = new FullSubModuleChild(module, "emailConnectors", "parsingStyles");

        public static FullSubModule EmailConnectors = new FullSubModule(module, "emailConnectors");

        public static GetSubModule EmailTokens = new GetSubModule(module, "emailTokens");

        public static FullSubModule IMaps = new FullSubModule(module, "imaps");

        // ImportsMassMaintenance

        public static FullSubModule InOutBoards = new FullSubModule(module, "inOutBoards");

        public static FullSubModule InOutTypes = new FullSubModule(module, "inOutTypes");

        // Info

        public static FullSubModule IntegratorLogins = new FullSubModule(module, "integratorLogins");

        public static GetSubModule KPICategories = new GetSubModule(module, "kpiCategories");

        public static GetSubModule KPIs = new GetSubModule(module, "kpis");

        public static GetSubModule Labs = new GetSubModule(module, "labs");

        public static FullSubModule LdapConfigurations = new FullSubModule(module, "ldapConfigurations");

        public static FullSubModule Links = new FullSubModule(module, "links");

        public static GetSubModuleChild LocationDepartments = new GetSubModuleChild(module, "locations", "departments");

        public static GetSubModuleChild LocationWorkRoles = new GetSubModuleChild(module, "locations", "workRoles");

        public static FullSubModule Locations = new FullSubModule(module, "locations");

        // ManagementNetworkSecurity

        public static FullSubModuleChild MemberAccruals = new FullSubModuleChild(module, "members", "accruals");

        public static FullSubModuleChild MemberCertifications = new FullSubModuleChild(module, "members", "certifications");

        public static FullSubModuleChild MemberDelegations = new FullSubModuleChild(module, "members", "delegations");

        public static FullSubModuleChild MemberSkills = new FullSubModuleChild(module, "members", "skills");

        public static FullSubModule MemberTypes = new FullSubModule(module, "members/types");

        public static MembersSubModule Members = new MembersSubModule(module, "members");

        // MenuEntries

        public static PartialSubModuleChild MenuEntryLocations = new PartialSubModuleChild(module, "menuEntries", "locations");

        public static FullSubModuleChild MyMemberCertifications = new FullSubModuleChild(module, "members", "myCertifications");

        // MyMembers

        // MySecuritys

        public static GetSubModule NotificationRecipients = new GetSubModule(module, "notificationRecipients");

        public static UpdateSubModule Others = new UpdateSubModule(module, "myCompany/other");

        public static GetSubModule ParsingTypes = new GetSubModule(module, "parsingTypes");

        public static GetSubModule ParsingVariables = new GetSubModule(module, "parsingVariables");

        public static FullSubModule PortalReports = new FullSubModule(module, "portalReports");

        public static FullSubModuleChild ReportCardDetails = new FullSubModuleChild(module, "reportCards", "details");

        public static FullSubModule ReportCards = new FullSubModule(module, "reportCards");

        // ReportingServices

        // Reports

        public static GetSubModuleChild SecurityRoleSettings = new GetSubModuleChild(module, "securityRoles", "settings");

        public static PartialSubModule SecurityRoles = new PartialSubModule(module, "securityRoles");

        // Services

        public static GetSubModule SetupScreens = new GetSubModule(module, "setupScreens");

        public static FullSubModule SkillCategories = new FullSubModule(module, "skillCategories");

        public static FullSubModule Skills = new FullSubModule(module, "skills");

        // SurveyQuestionValues

        // SurveyQuestions

        // Surveys

        public static UpdateSubModule TimeExpenses = new UpdateSubModule(module, "myCompany/timeExpense");

        public static FullSubModule TimeZoneSetups = new FullSubModule(module, "timeZoneSetups");

        public static GetSubModule TimeZones = new GetSubModule(module, "timeZones");

        public static FullSubModule TodayPageCategories = new FullSubModule(module, "todayPageCategorise");

        public static FullSubModule UserDefinedFields = new FullSubModule(module, "userDefinedFields");

        public static FullSubModuleChild WorkflowActionAutomateParameters = new FullSubModuleChild(module, "workflowActions", "automateParameters");

        public static FullSubModuleGrandChild WorkflowActions = new FullSubModuleGrandChild(module, "workflows", "events", "actions");

        public static GetSubModuleChild WorkflowAttachments = new GetSubModuleChild(module, "workflows", "attachments");

        // WorkflowEvents

        public static GetSubModuleChild WorkflowNotifyTypes = new GetSubModuleChild(module, "workflows", "notifyTypes");

        public static GetSubModule WorkflowTableTypes = new GetSubModule(module, "workflows/tableTypes");

        public static BaseSubModuleGrandChild WorkflowTriggerOptions = new BaseSubModuleGrandChild(module, "workflows", "triggers", "options");

        public static BaseSubModuleChild WorkflowTriggers = new BaseSubModuleChild(module, "workflows", "triggers");

        // Workflows
    }
}
