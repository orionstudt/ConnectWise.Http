using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Service.SubModules
{
    public class TicketsSubModule : FullSubModule
    {
        internal TicketsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Gets activities associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ActivitiesRequest(int ticketId, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            conditions.Conditions = new string[] { $"ticket/id={ticketId}" };
            string conditionStr = conditions.Build(CWConditionOptions.ConditionsAndPaging);
            return new CWRequest(CWHttpMethod.Get, $"sales/activities{conditionStr}");
        }

        /// <summary>
        /// Gets count of activities associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ActivitiesCountRequest(int ticketId)
        {
            var conditions = new CWRequestConditions
            {
                Conditions = new string[] { $"ticket/id={ticketId}" }
            };
            return new CWRequest(CWHttpMethod.Get, $"sales/activities/count{conditions.Build(CWConditionOptions.ConditionsAndPaging)}");
        }

        /// <summary>
        /// Gets time entries associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest TimeEntriesRequest(int ticketId, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            conditions.Conditions = new string[] { "(chargeToType=\"ServiceTicket\" OR chargeToType=\"ProjectTicket\")", $"chargeToId={ticketId}" };
            string conditionStr = conditions.Build(CWConditionOptions.ConditionsAndPaging);
            return new CWRequest(CWHttpMethod.Get, $"time/entries{conditionStr}");
        }

        /// <summary>
        /// Gets count of time entries associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest TimeEntriesCountRequest(int ticketId)
        {
            var conditions = new CWRequestConditions
            {
                Conditions = new string[] { "(chargeToType=\"ServiceTicket\" OR chargeToType=\"ProjectTicket\")", $"chargeToId={ticketId}" }
            };
            return new CWRequest(CWHttpMethod.Get, $"time/entries/count{conditions.Build(CWConditionOptions.ConditionsAndPaging)}");
        }

        /// <summary>
        /// Gets schedule entries associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ScheduleEntriesRequest(int ticketId, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            conditions.Conditions = new string[] { "type/id=4", $"objectId={ticketId}" };
            string conditionStr = conditions.Build(CWConditionOptions.ConditionsAndPaging);
            return new CWRequest(CWHttpMethod.Get, $"schedule/entries{conditionStr}");
        }

        /// <summary>
        /// Gets count of schedule entries associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ScheduleEntriesCountRequest(int ticketId)
        {
            var conditions = new CWRequestConditions
            {
                Conditions = new string[] { "type/id=4", $"objectId={ticketId}" }
            };
            return new CWRequest(CWHttpMethod.Get, $"schedule/entries/count{conditions.Build(CWConditionOptions.ConditionsAndPaging)}");
        }

        /// <summary>
        /// Gets documents associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DocumentsRequest(int ticketId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.Pagination, appendToExisting: true) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"system/documents?recordType=Ticket&recordId={ticketId}{conditionStr}");
        }

        /// <summary>
        /// Gets count of documents associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DocumentsCountRequest(int ticketId)
        {
            return new CWRequest(CWHttpMethod.Get, $"system/documents/count?recordType=Ticket&recordId={ticketId}");
        }

        /// <summary>
        /// Gets products associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ProductsRequest(int ticketId, CWRequestConditions conditions = null)
        {
            if (conditions == null) { conditions = new CWRequestConditions(); }
            conditions.Conditions = new string[] { "chargeToType=\"Ticket\"", $"chargeToId={ticketId}" };
            string conditionStr = conditions.Build(CWConditionOptions.ConditionsAndPaging);
            return new CWRequest(CWHttpMethod.Get, $"procurement/products{conditionStr}");
        }

        /// <summary>
        /// Gets count of products associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ProductsCountRequest(int ticketId)
        {
            var conditions = new CWRequestConditions
            {
                Conditions = new string[] { "chargeToType=\"Ticket\"", $"chargeToId={ticketId}" }
            };
            return new CWRequest(CWHttpMethod.Get, $"procurement/products/count{conditions.Build(CWConditionOptions.ConditionsAndPaging)}");
        }

        /// <summary>
        /// Gets configurations associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="conditions">This endpoint only accepts Paging conditions.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ConfigurationsRequest(int ticketId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.Pagination) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{ticketId}/configurations{conditionStr}");
        }

        /// <summary>
        /// Gets specific configuration associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="configId">Specified Configuration ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ConfigurationsRequest(int ticketId, int configId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{ticketId}/configurations/{configId}");
        }

        /// <summary>
        /// Gets count of configurations associated to the ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ConfigurationsCountRequest(int ticketId)
        {
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix()}/{ticketId}/configurations/count");
        }

        /// <summary>
        /// Associate a configuration with the specified ticket.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="content">Serialized configuration reference.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ConfigurationCreateRequest(int ticketId, string content)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{ticketId}/configurations", content);
        }

        /// <summary>
        /// Deletes association between specified ticket and specified configuration.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="configId">Specified Configuration ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ConfigurationDeleteRequest(int ticketId, int configId)
        {
            return new CWRequest(CWHttpMethod.Delete, $"{getPrefix()}/{ticketId}/configurations/{configId}");
        }

        /// <summary>
        /// Merge the specified ticket with the tickets defined in the serialized content and set to the defined status.
        /// </summary>
        /// <param name="ticketId">Specified Ticket ID.</param>
        /// <param name="content">Serialized ticket merge content.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest MergeRequest(int ticketId, string content)
        {
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/{ticketId}/merge", content);
        }
    }
}
