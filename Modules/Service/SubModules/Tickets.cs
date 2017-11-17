using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Service.SubModules
{
    public class TicketsSubModule : DeleteSubModule
    {
        internal TicketsSubModule(string module, string endpoint) : base(module, endpoint) { }
    }
}
