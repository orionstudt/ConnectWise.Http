using ConnectWise.Http.Modules.Project.SubModules;
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

        public static ProjectContactsSubModule ProjectContacts = new ProjectContactsSubModule(module, "projects", "contacts");

        public static FullSubModuleChild ProjectNotes = new FullSubModuleChild(module, "projects", "notes");

        public static FullSubModuleChild ProjectPhases = new FullSubModuleChild(module, "projects", "phases");

        public static FullSubModule ProjectStatuses = new FullSubModule(module, "statuses");

        public static FullSubModule Projects = new FullSubModule(module, "projects");

        public static FullSubModuleChild ProjectTeammembers = new FullSubModuleChild(module, "projects", "teamMembers");
    }
}
