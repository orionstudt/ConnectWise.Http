using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Project
{
    public static class ProjectModule
    {
        private static string module = "project";

        public static DeleteSubModuleChild ProjectNotes = new DeleteSubModuleChild(module, "projects", "notes");

        public static DeleteSubModuleChild ProjectPhases = new DeleteSubModuleChild(module, "projects", "phases");

        public static DeleteSubModule ProjectStatuses = new DeleteSubModule(module, "statuses");

        public static DeleteSubModule Projects = new DeleteSubModule(module, "projects");

        public static DeleteSubModuleChild ProjectTeammembers = new DeleteSubModuleChild(module, "projects", "teamMembers");
    }
}
