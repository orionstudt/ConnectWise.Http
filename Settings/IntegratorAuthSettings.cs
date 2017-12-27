using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.Options
{
    public class IntegratorAuthSettings : IAuthSettings
    {
        private string login;
        private string password;

        public IntegratorAuthSettings(string integratorLogin, string integratorPassword)
        {
            login = integratorLogin;
            password = integratorPassword;
        }

        public AuthenticationHeaderValue BuildHeader(string companyName)
        {
            return new AuthenticationHeaderValue(
                            "Basic", Convert.ToBase64String(
                                Encoding.ASCII.GetBytes($"{companyName}+{login}:{password}")));
        }
    }
}
