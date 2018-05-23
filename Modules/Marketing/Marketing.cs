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
        private static string module = "marketing";

        public static FullSubModuleChild CampaignAudits = new FullSubModuleChild(module, "campaigns", "audits");

        public static FullSubModuleChild CampaignEmailsOpened = new FullSubModuleChild(module, "campaigns", "emailsOpened");

        public static FullSubModuleChild CampaignFormsSubmitted = new FullSubModuleChild(module, "campaigns", "formsSubmitted");

        public static FullSubModuleChild CamapaignLinksClicked = new FullSubModuleChild(module, "campaigns", "linksClicked");

        public static FullSubModule CampaignStatuses = new FullSubModule(module, "campaigns/statuses");

        public static FullSubModule CampaignSubTypes = new FullSubModule(module, "campaigns/subTypes");

        public static FullSubModule CampaignTypes = new FullSubModule(module, "campaigns/types");

        public static CampaignsSubModule Campaigns = new CampaignsSubModule(module, "campaigns");

        public static FullSubModuleChild GroupCompanies = new FullSubModuleChild(module, "groups", "companies");

        public static FullSubModuleChild GroupContacts = new FullSubModuleChild(module, "groups", "contacts");

        public static FullSubModule Groups = new FullSubModule(module, "groups");

        public static GetSubModuleChild LegacyCampaignSubTypes = new GetSubModuleChild(module, "campaigns/types", "subTypes");
    }
}
