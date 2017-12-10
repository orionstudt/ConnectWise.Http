using ConnectWise.Http.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Modules.Schedule.SubModules
{
    public class ScheduleColorsSubModule : UpdateSubModule
    {
        internal ScheduleColorsSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Clear Schedule Color.
        /// </summary>
        /// <param name="colorId">The ID of the Schedule Color to be cleared.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ClearRequest(int colorId)
        {
            return new CWRequest(CWHttpMethod.Post, string.Format("{0}/{1}/clear", getPrefix(), colorId));
        }

        /// <summary>
        /// Reset Schedule Colors.
        /// </summary>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ResetRequest()
        {
            return new CWRequest(CWHttpMethod.Post, string.Concat(getPrefix(), "/reset"));
        }
    }
}
