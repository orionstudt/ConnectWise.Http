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
        private const string module = "service";

        public static readonly FullSubModuleChild BoardAutoAssignResources = new FullSubModuleChild(module, "boards", "autoAssignResources");

        public static readonly FullSubModuleChild BoardAutoTemplates = new FullSubModuleChild(module, "boards", "autoTemplates");

        public static readonly PartialSubModuleChild BoardExcludedMembers = new PartialSubModuleChild(module, "boards", "excludedMembers");

        public static readonly UpdateSubModuleGrandChild BoardItemAssociations = new UpdateSubModuleGrandChild(module, "boards", "items", "associations");

        public static readonly FullSubModuleChild BoardItems = new FullSubModuleChild(module, "boards", "items");

        public static readonly FullSubModuleChild BoardNotifications = new FullSubModuleChild(module, "boards", "notifications");

        public static readonly FullSubModuleChild BoardStatuses = new FullSubModuleChild(module, "boards", "statuses");

        public static readonly FullSubModuleChild BoardSubTypes = new FullSubModuleChild(module, "boards", "subtypes");

        public static readonly FullSubModuleChild BoardTeams = new FullSubModuleChild(module, "boards", "teams");

        public static readonly GetSubModuleChild BoardTypeSubTypeItemAssociations = new GetSubModuleChild(module, "boards", "typeSubTimeItemAssociations");

        public static readonly FullSubModuleChild BoardTypes = new FullSubModuleChild(module, "boards", "types");

        public static readonly BoardsSubModule Boards = new BoardsSubModule(module, "boards");

        public static readonly FullSubModule Codes = new FullSubModule(module, "codes");

        public static readonly UpdateSubModule Impacts = new UpdateSubModule(module, "impacts");

        public static readonly FullSubModule KnowledgeBaseArticles = new FullSubModule(module, "knowledgeBaseArticles");

        public static readonly PrioritiesSubModule Priorities = new PrioritiesSubModule(module, "priorities");

        public static readonly FullSubModuleChild SLAPriorities = new FullSubModuleChild(module, "SLAs", "priorities");

        public static readonly FullSubModule SLAs = new FullSubModule(module, "SLAs");

        public static readonly FullSubModule ServiceEmailTemplates = new FullSubModule(module, "emailTemplates");

        public static readonly FullSubModule Locations = new FullSubModule(module, "locations");

        public static readonly FullSubModule ServiceSignoffs = new FullSubModule(module, "serviceSignoff");

        public static readonly FullSubModuleChild ServiceSurveyQuestions = new FullSubModuleChild(module, "surveys", "questions");

        public static readonly FullSubModule ServiceSurveys = new FullSubModule(module, "surveys");

        public static readonly GetSubModule ServiceTeams = new GetSubModule(module, "teams");

        public static readonly GetSubModule ServiceTemplates = new GetSubModule(module, "templates");

        public static readonly UpdateSubModule Severities = new UpdateSubModule(module, "severities");

        public static readonly FullSubModule Sources = new FullSubModule(module, "sources");

        public static readonly GetSubModule StatusExternalIntegrationReferences = new GetSubModule(module, "statusExternalIntegrationReferences");

        public static readonly FullSubModuleGrandChild SurveyOptions = new FullSubModuleGrandChild(module, "surveys", "questions", "options");

        public static readonly FullSubModuleChild SurveyResults = new FullSubModuleChild(module, "surveys", "results");

        public static readonly PartialSubModule TeamMembers = new PartialSubModule(module, "teamMembers");

        public static readonly FullSubModuleChild TicketNotes = new FullSubModuleChild(module, "tickets", "notes");

        public static readonly FullSubModuleChild TicketTasks = new FullSubModuleChild(module, "tickets", "tasks");

        public static readonly TicketsSubModule Tickets = new TicketsSubModule(module, "tickets");
    }
}
