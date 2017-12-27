using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public interface IAuthSettings
    {
        AuthenticationHeaderValue BuildHeader(string companyName);
    }
}
