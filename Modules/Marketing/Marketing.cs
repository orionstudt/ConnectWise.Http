using ConnectWise.Http.Modules.Marketing.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Marketing
{
    public static class MarketingModule
    {
        private const string module = "marketing";

        public static readonly FullSubModuleChild CampaignAudits = new FullSubModuleChild(module, "campaigns", "audits");

        public static readonly FullSubModuleChild CampaignEmailsOpened = new FullSubModuleChild(module, "campaigns", "emailsOpened");

        public static readonly FullSubModuleChild CampaignFormsSubmitted = new FullSubModuleChild(module, "campaigns", "formsSubmitted");

        public static readonly FullSubModuleChild CamapaignLinksClicked = new FullSubModuleChild(module, "campaigns", "linksClicked");

        public static readonly FullSubModule CampaignStatuses = new FullSubModule(module, "campaigns/statuses");

        public static readonly FullSubModule CampaignSubTypes = new FullSubModule(module, "campaigns/subTypes");

        public static readonly FullSubModule CampaignTypes = new FullSubModule(module, "campaigns/types");

        public static readonly CampaignsSubModule Campaigns = new CampaignsSubModule(module, "campaigns");

        public static readonly FullSubModuleChild GroupCompanies = new FullSubModuleChild(module, "groups", "companies");

        public static readonly FullSubModuleChild GroupContacts = new FullSubModuleChild(module, "groups", "contacts");

        public static readonly FullSubModule Groups = new FullSubModule(module, "groups");

        public static readonly GetSubModuleChild LegacyCampaignSubTypes = new GetSubModuleChild(module, "campaigns/types", "subTypes");
    }
}
