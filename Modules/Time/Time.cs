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
        private static string module = "time";

        public static FullSubModule ActivityStopwatches = new FullSubModule(module, "activitystopwatches");

        public static FullSubModuleChild ChargeCodeExpenseTypes = new FullSubModuleChild(module, "chargeCodes", "expenseTypes");

        public static FullSubModule ChargeCodes = new FullSubModule(module, "chargeCodes");

        public static FullSubModule ScheduleStopwatches = new FullSubModule(module, "schedulestopwatches");

        public static FullSubModule TicketStopwatches = new FullSubModule(module, "ticketstopwatches");

        public static FullSubModuleChild TimeAccrualDetials = new FullSubModuleChild(module, "accruals", "details");

        public static FullSubModule TimeAccruals = new FullSubModule(module, "accruals");

        public static TimeEntriesSubModule TimeEntries = new TimeEntriesSubModule(module, "entries");


    }
}
