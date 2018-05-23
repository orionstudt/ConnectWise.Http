using ConnectWise.Http.Modules.Time.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Time
{
    public static class TimeModule
    {
        private const string module = "time";

        public static readonly FullSubModule ActivityStopwatches = new FullSubModule(module, "activitystopwatches");

        public static readonly FullSubModuleChild ChargeCodeExpenseTypes = new FullSubModuleChild(module, "chargeCodes", "expenseTypes");

        public static readonly FullSubModule ChargeCodes = new FullSubModule(module, "chargeCodes");

        public static readonly FullSubModule ScheduleStopwatches = new FullSubModule(module, "schedulestopwatches");

        public static readonly FullSubModule TicketStopwatches = new FullSubModule(module, "ticketstopwatches");

        public static readonly FullSubModuleChild TimeAccrualDetials = new FullSubModuleChild(module, "accruals", "details");

        public static readonly FullSubModule TimeAccruals = new FullSubModule(module, "accruals");

        public static readonly TimeEntriesSubModule TimeEntries = new TimeEntriesSubModule(module, "entries");

        public static readonly TimePeriodSetupsSubModule TimePeriodSetups = new TimePeriodSetupsSubModule(module, "timePeriodSetups");

        public static readonly GetSubModuleChild TimePeriods = new GetSubModuleChild(module, "timePeriodSetups", "periods");

        public static readonly TimeSheetsSubModule TimeSheets = new TimeSheetsSubModule(module, "sheets");

        public static readonly FullSubModuleChild WorkRoleLocations = new FullSubModuleChild(module, "workRoles", "locations");

        public static readonly FullSubModule WorkRoles = new FullSubModule(module, "workRoles");

        public static readonly GetSubModule WorkTypeExternalIntegrationReferences = new GetSubModule(module, "workTypeExternalIntegrationReferences");

        public static readonly FullSubModule WorkTypes = new FullSubModule(module, "workTypes");
    }
}
