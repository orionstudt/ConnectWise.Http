using ConnectWise.Http.Modules.Service.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Service
{
    public static class ServiceModule
    {
        private static string module = "service";

        public static FullSubModuleChild BoardAutoAssignResources = new FullSubModuleChild(module, "boards", "autoAssignResources");

        public static FullSubModuleChild BoardAutoTemplates = new FullSubModuleChild(module, "boards", "autoTemplates");

        public static PartialSubModuleChild BoardExcludedMembers = new PartialSubModuleChild(module, "boards", "excludedMembers");

        public static UpdateSubModuleGrandChild BoardItemAssociations = new UpdateSubModuleGrandChild(module, "boards", "items", "associations");

        public static FullSubModuleChild BoardItems = new FullSubModuleChild(module, "boards", "items");

        public static FullSubModuleChild BoardNotifications = new FullSubModuleChild(module, "boards", "notifications");

        public static FullSubModuleChild BoardStatuses = new FullSubModuleChild(module, "boards", "statuses");

        public static FullSubModuleChild BoardSubTypes = new FullSubModuleChild(module, "boards", "subtypes");

        public static FullSubModuleChild BoardTeams = new FullSubModuleChild(module, "boards", "teams");

        public static BaseSubModuleChild BoardTypeSubTypeItemAssociations = new BaseSubModuleChild(module, "boards", "typeSubTimeItemAssociations");

        public static FullSubModuleChild BoardTypes = new FullSubModuleChild(module, "boards", "types");

        public static BoardsSubModule Boards = new BoardsSubModule(module, "boards");

        public static FullSubModule Codes = new FullSubModule(module, "codes");

        public static UpdateSubModule Impacts = new UpdateSubModule(module, "impacts");

        public static FullSubModule KnowledgeBaseArticles = new FullSubModule(module, "knowledgeBaseArticles");

        public static PrioritiesSubModule Priorities = new PrioritiesSubModule(module, "priorities");

        public static FullSubModuleChild SLAPriorities = new FullSubModuleChild(module, "SLAs", "priorities");

        public static FullSubModule SLAs = new FullSubModule(module, "SLAs");

        public static FullSubModule ServiceEmailTemplates = new FullSubModule(module, "emailTemplates");

        public static FullSubModule Locations = new FullSubModule(module, "locations");

        public static FullSubModule ServiceSignoffs = new FullSubModule(module, "serviceSignoff");

        public static FullSubModuleChild ServiceSurveyQuestions = new FullSubModuleChild(module, "surveys", "questions");

        public static FullSubModule ServiceSurveys = new FullSubModule(module, "surveys");

        public static BaseSubModule ServiceTeams = new BaseSubModule(module, "teams");

        public static BaseSubModule ServiceTemplates = new BaseSubModule(module, "templates");

        public static UpdateSubModule Severities = new UpdateSubModule(module, "severities");

        public static FullSubModule Sources = new FullSubModule(module, "sources");

        public static BaseSubModule StatusExternalIntegrationReferences = new BaseSubModule(module, "statusExternalIntegrationReferences");

        public static FullSubModuleGrandChild SurveyOptions = new FullSubModuleGrandChild(module, "surveys", "questions", "options");

        public static FullSubModuleChild SurveyResults = new FullSubModuleChild(module, "surveys", "results");

        public static PartialSubModule TeamMembers = new PartialSubModule(module, "teamMembers");

        public static FullSubModuleChild TicketNotes = new FullSubModuleChild(module, "tickets", "notes");

        public static FullSubModuleChild TicketTasks = new FullSubModuleChild(module, "tickets", "tasks");

        public static TicketsSubModule Tickets = new TicketsSubModule(module, "tickets");
    }
}
