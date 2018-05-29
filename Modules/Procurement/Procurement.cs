using ConnectWise.Http.Modules.Procurement.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Procurement
{
    public static class Procurement
    {
        private const string module = "procurement";

        public static readonly PartialSubModuleChild AdjustmentDetails = new PartialSubModuleChild(module, "adjustments", "details");

        public static readonly FullSubModule AdjustmentTypes = new FullSubModule(module, "adjustments/types");

        public static readonly FullSubModule Adjustments = new FullSubModule(module, "adjustments");

        public static readonly FullSubModuleChild CatalogComponents = new FullSubModuleChild(module, "catalog", "components");

        public static readonly CatalogsItemSubModule CatalogsItem = new CatalogsItemSubModule(module, "catalog");

        public static readonly FullSubModule Catagories = new FullSubModule(module, "catagories");

        public static readonly FullSubModuleChild LegacySubCategories = new FullSubModuleChild(module, "catagories", "subCategories");

        public static readonly FullSubModule Manufacturers = new FullSubModule(module, "manufacturers");

        public static readonly FullSubModuleGrandChild PricingBreaks = new FullSubModuleGrandChild(module, "pricingSchedules", "details", "breaks");

        public static readonly FullSubModuleChild PricingDetails = new FullSubModuleChild(module, "pricingSchedules", "details");

        public static readonly FullSubModule PricingSchedules = new FullSubModule(module, "pricingSchedules");

        public static readonly UpdateSubModule ProcurementSettings = new UpdateSubModule(module, "settings");

        public static readonly FullSubModuleChild ProductComponents = new FullSubModuleChild(module, "products", "components");

        public static readonly FullSubModuleChild ProductPickingShippingDetails = new FullSubModuleChild(module, "products", "pickingShippingDetails");

        public static readonly FullSubModule ProductTypes = new FullSubModule(module, "types");

        public static readonly FullSubModule ProductsItem = new FullSubModule(module, "products");

        public static readonly FullSubModuleChild PurchaseOrderLineItems = new FullSubModuleChild(module, "purchaseOrders", "lineItems");

        public static readonly FullSubModuleChild PurchaseOrderStatusEmailTemplates = new FullSubModuleChild(module, "purchaseOrderStatuses", "emailTemplates");

        public static readonly FullSubModuleChild PurchaseOrderStatusNotifications = new FullSubModuleChild(module, "purchaseOrderStatuses", "notifications");

        public static readonly FullSubModule PurchaseOrderStatuses = new FullSubModule(module, "purchaseOrderStatuses");

        public static readonly FullSubModule PurchaseOrders = new FullSubModule(module, "purchaseOrders");

        public static readonly FullSubModule RmaActions = new FullSubModule(module, "rmaActions");

        public static readonly FullSubModule RmaDispositions = new FullSubModule(module, "rmaDispositions");

        public static readonly FullSubModuleChild RmaStatusEmailTemplates = new FullSubModuleChild(module, "rmaStatuses", "emailTemplates");

        public static readonly FullSubModuleChild RmaStatusNotifications = new FullSubModuleChild(module, "rmaStatuses", "notifications");

        public static readonly FullSubModule RmaStatuses = new FullSubModule(module, "rmaStatuses");

        public static readonly FullSubModule ShipmentMethods = new FullSubModule(module, "shipmentMethods");

        public static readonly FullSubModule SubCategories = new FullSubModule(module, "subCategories");

        public static readonly FullSubModuleChild UnitOfMeasureCategories = new FullSubModuleChild(module, "unitOfMeasures", "conversions");

        public static readonly FullSubModule UnitOfMeasures = new FullSubModule(module, "unitOfMeasures");

        public static readonly FullSubModule WarehouseBins = new FullSubModule(module, "warehouseBins");

        public static readonly FullSubModule Warehouses = new FullSubModule(module, "warehouses");
    }
}
