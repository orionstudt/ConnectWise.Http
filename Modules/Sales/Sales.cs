using ConnectWise.Http.Modules.Sales.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Sales
{
    public static class SalesModule
    {
        private static string module = "sales";

        public static FullSubModule Activities = new FullSubModule(module, "activities");

        public static FullSubModule ActivityStatuses = new FullSubModule(module, "activities/statuses");

        public static FullSubModule ActivityTypes = new FullSubModule(module, "activities/types");

        public static FullSubModule Commissions = new FullSubModule(module, "commissions");

        public static OpportunitiesSubModule Opportunities = new OpportunitiesSubModule(module, "opportunities");

        public static FullSubModuleChild OpportunityContacts = new FullSubModuleChild(module, "opportunities", "contacts");

        public static FullSubModuleChild OpportunityForecasts = new FullSubModuleChild(module, "opportunities", "forecast");

        public static FullSubModuleChild OpportunityNotes = new FullSubModuleChild(module, "opportunities", "notes");

        public static FullSubModule OpportunityRatings = new FullSubModule(module, "opportunities/ratings");

        public static FullSubModule OpportunityStages = new FullSubModule(module, "stages");

        public static FullSubModule OpportunityStatuses = new FullSubModule(module, "opportunities/statuses");

        public static FullSubModuleChild OpportunityTeams = new FullSubModuleChild(module, "opportunities", "team");

        public static FullSubModule OpportunityTypes = new FullSubModule(module, "opportunities/types");

        public static FullSubModuleChild OrderStatusNotifications = new FullSubModuleChild(module, "orders/statuses", "notifications");

        public static FullSubModule OrderStatuses = new FullSubModule(module, "orders/statuses");

        public static FullSubModuleChild OrderStatusesEmailTemplates = new FullSubModuleChild(module, "orders/statuses", "emailTemplates");

        public static FullSubModule Orders = new FullSubModule(module, "orders");

        public static FullSubModule Roles = new FullSubModule(module, "roles");

        public static FullSubModule SalesProbabilities = new FullSubModule(module, "probabilities");

        public static FullSubModule SalesQuotas = new FullSubModule(module, "quotas");

        public static FullSubModuleChild SalesTeamMembers = new FullSubModuleChild(module, "salesTeams", "members");

        public static FullSubModule SalesTeams = new FullSubModule(module, "salesTeams");
    }
}
