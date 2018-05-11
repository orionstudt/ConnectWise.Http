using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// The HTTP Method of a CWRequest. CW needs a custom enumerator for their PATCH Method.
    /// </summary>
    public enum CWHttpMethod
    {
        Get,
        Put,
        Patch,
        Post,
        Delete
    }
}
