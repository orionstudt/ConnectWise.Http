using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class CWPatch
    {
        public string Op { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
    }

    public static class CWPatchOperation
    {
        public const string Add = "add";
        public const string Replace = "replace";
        public const string Remove = "remove";
    }
}
