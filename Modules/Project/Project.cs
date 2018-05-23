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
        private const string module = "project";

        public static readonly ProjectContactsSubModule ProjectContacts = new ProjectContactsSubModule(module, "projects", "contacts");

        public static readonly FullSubModuleChild ProjectNotes = new FullSubModuleChild(module, "projects", "notes");

        public static readonly FullSubModuleChild ProjectPhases = new FullSubModuleChild(module, "projects", "phases");

        public static readonly FullSubModule ProjectStatuses = new FullSubModule(module, "statuses");

        public static readonly FullSubModule Projects = new FullSubModule(module, "projects");

        public static readonly FullSubModuleChild ProjectTeammembers = new FullSubModuleChild(module, "projects", "teamMembers");
    }
}
