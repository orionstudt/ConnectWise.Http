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
        private static string module = "schedule";

        public static ScheduleColorsSubModule ScheduleColors = new ScheduleColorsSubModule(module, "colors");

        public static BaseSubModuleChild ScheduleDetails = new BaseSubModuleChild(module, "entries", "details");

        public static FullSubModule ScheduleEntries = new FullSubModule(module, "entries");

        public static UpdateSubModule ScheduleReminderTimes = new UpdateSubModule(module, "reminderTimes");

        public static FullSubModule ScheduleStatuses = new FullSubModule(module, "statuses");

        public static FullSubModule ScheduleTypes = new FullSubModule(module, "types");
    }
}
