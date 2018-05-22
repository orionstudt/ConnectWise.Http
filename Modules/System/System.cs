using ConnectWise.Http.Modules.System.SubModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.System
{
    public static class SystemModule
    {
        private static string module = "system";

        public static MembersSubModule Members = new MembersSubModule(module, "members");
    }
}
