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

        public static DeleteSubModuleChild BoardAutoAssignResources = new DeleteSubModuleChild(module, "boards", "autoAssignResources");

        public static DeleteSubModuleChild BoardAutoTemplates = new DeleteSubModuleChild(module, "boards", "autoTemplates");

        // BoardExcludedMembers

        // BoardItemAssociations

        public static DeleteSubModuleChild BoardItems = new DeleteSubModuleChild(module, "boards", "items");

        public static DeleteSubModuleChild BoardNotifications = new DeleteSubModuleChild(module, "boards", "notifications");

        public static DeleteSubModuleChild BoardStatuses = new DeleteSubModuleChild(module, "boards", "statuses");

        public static DeleteSubModuleChild BoardSubTypes = new DeleteSubModuleChild(module, "boards", "subtypes");

        public static DeleteSubModuleChild BoardTeams = new DeleteSubModuleChild(module, "boards", "teams");

        public static BaseSubModuleChild BoardTypeSubTypeItemAssociations = new BaseSubModuleChild(module, "boards", "typeSubTimeItemAssociations");

        public static DeleteSubModuleChild BoardTypes = new DeleteSubModuleChild(module, "boards", "types");

        public static BoardsSubModule Boards = new BoardsSubModule(module, "boards");

        public static DeleteSubModule Codes = new DeleteSubModule(module, "codes");

        public static UpdateSubModule Impacts = new UpdateSubModule(module, "impacts");

        public static DeleteSubModule KnowledgeBaseArticles = new DeleteSubModule(module, "knowledgeBaseArticles");

        // Priorities

        public static DeleteSubModuleChild SLAPriorities = new DeleteSubModuleChild(module, "SLAs", "priorities");

        public static DeleteSubModule SLAs = new DeleteSubModule(module, "SLAs");

        public static DeleteSubModule ServiceEmailTemplates = new DeleteSubModule(module, "emailTemplates");

        public static DeleteSubModule Locations = new DeleteSubModule(module, "locations");

        public static DeleteSubModule ServiceSignoffs = new DeleteSubModule(module, "serviceSignoff");

        public static DeleteSubModuleChild ServiceSurveyQuestions = new DeleteSubModuleChild(module, "surveys", "questions");

        public static DeleteSubModule ServiceSurveys = new DeleteSubModule(module, "surveys");

        public static BaseSubModule ServiceTeams = new BaseSubModule(module, "teams");

        public static BaseSubModule ServiceTemplates = new BaseSubModule(module, "templates");

        public static UpdateSubModule Severities = new UpdateSubModule(module, "severities");

        public static DeleteSubModule Sources = new DeleteSubModule(module, "sources");

        public static BaseSubModule StatusExternalIntegrationReferences = new BaseSubModule(module, "statusExternalIntegrationReferences");

        // SurveyOptions

        public static DeleteSubModuleChild SurveyResults = new DeleteSubModuleChild(module, "surveys", "resuts");

        // TeamMembers

        public static DeleteSubModuleChild TicketNotes = new DeleteSubModuleChild(module, "tickets", "notes");

        public static DeleteSubModuleChild TicketTasks = new DeleteSubModuleChild(module, "tickets", "tasks");

        public static TicketsSubModule Tickets = new TicketsSubModule(module, "tickets");
    }
}
