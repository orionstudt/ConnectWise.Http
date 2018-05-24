using ConnectWise.Http.Modules.Schedule.SubModules;
using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Schedule
{
    public static class ScheduleModule
    {
        private const string module = "schedule";

        public static readonly ScheduleColorsSubModule ScheduleColors = new ScheduleColorsSubModule(module, "colors");

        public static readonly GetSubModuleChild ScheduleDetails = new GetSubModuleChild(module, "entries", "details");

        public static readonly FullSubModule ScheduleEntries = new FullSubModule(module, "entries");

        public static readonly UpdateSubModule ScheduleReminderTimes = new UpdateSubModule(module, "reminderTimes");

        public static readonly FullSubModule ScheduleStatuses = new FullSubModule(module, "statuses");

        public static readonly FullSubModule ScheduleTypes = new FullSubModule(module, "types");
    }
}
