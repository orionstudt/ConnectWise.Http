using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// When executing a PATCH operation on the CW API your request body will need to be an enumerable of CWPatch.
    /// </summary>
    public class CWPatch
    {
        /// <summary>
        /// The operation to be executed. Try using CWPatchOperation constants.
        /// </summary>
        public string Op { get; set; }

        /// <summary>
        /// The path the operation will be executed against.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The value to be used for a Replace operation.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// CWPatchOperation constants can be used to apply an operation to the "Op" field of a CWPatch object.
    /// </summary>
    public static class CWPatchOperation
    {
        public const string Add = "add";
        public const string Replace = "replace";
        public const string Remove = "remove";
    }
}
