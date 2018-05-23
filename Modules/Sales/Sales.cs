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
        private const string module = "sales";

        public static readonly FullSubModule Activities = new FullSubModule(module, "activities");

        public static readonly FullSubModule ActivityStatuses = new FullSubModule(module, "activities/statuses");

        public static readonly FullSubModule ActivityTypes = new FullSubModule(module, "activities/types");

        public static readonly FullSubModule Commissions = new FullSubModule(module, "commissions");

        public static readonly OpportunitiesSubModule Opportunities = new OpportunitiesSubModule(module, "opportunities");

        public static readonly FullSubModuleChild OpportunityContacts = new FullSubModuleChild(module, "opportunities", "contacts");

        public static readonly FullSubModuleChild OpportunityForecasts = new FullSubModuleChild(module, "opportunities", "forecast");

        public static readonly FullSubModuleChild OpportunityNotes = new FullSubModuleChild(module, "opportunities", "notes");

        public static readonly FullSubModule OpportunityRatings = new FullSubModule(module, "opportunities/ratings");

        public static readonly FullSubModule OpportunityStages = new FullSubModule(module, "stages");

        public static readonly FullSubModule OpportunityStatuses = new FullSubModule(module, "opportunities/statuses");

        public static readonly FullSubModuleChild OpportunityTeams = new FullSubModuleChild(module, "opportunities", "team");

        public static readonly FullSubModule OpportunityTypes = new FullSubModule(module, "opportunities/types");

        public static readonly FullSubModuleChild OrderStatusNotifications = new FullSubModuleChild(module, "orders/statuses", "notifications");

        public static readonly FullSubModule OrderStatuses = new FullSubModule(module, "orders/statuses");

        public static readonly FullSubModuleChild OrderStatusesEmailTemplates = new FullSubModuleChild(module, "orders/statuses", "emailTemplates");

        public static readonly FullSubModule Orders = new FullSubModule(module, "orders");

        public static readonly FullSubModule Roles = new FullSubModule(module, "roles");

        public static readonly FullSubModule SalesProbabilities = new FullSubModule(module, "probabilities");

        public static readonly FullSubModule SalesQuotas = new FullSubModule(module, "quotas");

        public static readonly FullSubModuleChild SalesTeamMembers = new FullSubModuleChild(module, "salesTeams", "members");

        public static readonly FullSubModule SalesTeams = new FullSubModule(module, "salesTeams");
    }
}
