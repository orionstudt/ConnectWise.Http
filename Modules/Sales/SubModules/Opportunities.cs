using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Sales.SubModules
{
    public class OpportunitiesSubModule : FullSubModule
    {
        internal OpportunitiesSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Convert Opportunity to Service Ticket
        /// </summary>
        /// <param name="opportunityId">Specified Opportunity ID.</param>
        /// <param name="serializedBody">Serialized OpportunityToServiceTicketConversion object.</param>
        /// <param name="conditions">This endpoint only accepts the Fields condition.</param>
        /// <returns></returns>
        public CWRequest ConvertToServiceTicketRequest(int opportunityId, string serializedBody, CWRequestConditions conditions = null)
        {
            if (conditions == null) conditions = new CWRequestConditions();
            var conditionStr = conditions.ToUriConditions(CWConditionOptions.OnlyFields);
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{opportunityId}/convertToServiceTicket{conditionStr}");
        }

        /// <summary>
        /// Convert Opportunity to Project
        /// </summary>
        /// <param name="opportunityId">Specified Opportunity ID.</param>
        /// <param name="serializedBody">Serialized OpportunityToProjectConversion object.</param>
        /// <param name="conditions">This endpoint only accepts the Fields condition.</param>
        /// <returns></returns>
        public CWRequest ConvertToProjectRequest(int opportunityId, string serializedBody, CWRequestConditions conditions = null)
        {
            if (conditions == null) conditions = new CWRequestConditions();
            var conditionStr = conditions.ToUriConditions(CWConditionOptions.OnlyFields);
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{opportunityId}/convertToProject{conditionStr}");
        }

        /// <summary>
        /// Convert Opportunity to Sales Order
        /// </summary>
        /// <param name="opportunityId">Specified Opportunity ID.</param>
        /// <param name="serializedBody">Serialized OpportunityToSalesOrderConversion object.</param>
        /// <param name="conditions">This endpoint only accepts the Fields condition.</param>
        /// <returns></returns>
        public CWRequest ConvertToSalesOrderRequest(int opportunityId, string serializedBody, CWRequestConditions conditions = null)
        {
            if (conditions == null) conditions = new CWRequestConditions();
            var conditionStr = conditions.ToUriConditions(CWConditionOptions.OnlyFields);
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{opportunityId}/convertToSalesOrder{conditionStr}");
        }

        /// <summary>
        /// Convert Opportunity to Agreement
        /// </summary>
        /// <param name="opportunityId">Specified Opportunity ID.</param>
        /// <param name="serializedBody">Serialized OpportunityToAgreementConversion object.</param>
        /// <param name="conditions">This endpoint only accepts the Fields condition.</param>
        /// <returns></returns>
        public CWRequest ConvertToAgreementRequest(int opportunityId, string serializedBody, CWRequestConditions conditions = null)
        {
            if (conditions == null) conditions = new CWRequestConditions();
            var conditionStr = conditions.ToUriConditions(CWConditionOptions.OnlyFields);
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{opportunityId}/convertToAgreement{conditionStr}");
        }
    }
}
