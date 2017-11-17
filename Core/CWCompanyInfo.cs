using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class CWCompanyInfo
    {
        public string CompanyName { get; private set; }

        public string Codebase { get; private set; }

        public string VersionCode { get; private set; }

        public string CompanyID { get; private set; }

        public bool IsCloud { get; private set; }

        internal CWCompanyInfo() { }
    }
}
