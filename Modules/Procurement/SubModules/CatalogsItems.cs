using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Procurement.SubModules
{
    public class CatalogsItemSubModule : FullSubModule
    {
        internal CatalogsItemSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Get Inventory Catalog Quantity On Hand
        /// </summary>
        /// <param name="catalogItemIdentitifer">Identifier of specified Catalog Item.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest QuantityOnHandRequest(string catalogItemIdentitifer)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{catalogItemIdentitifer}/quantityOnHand");
        }
    }
}
