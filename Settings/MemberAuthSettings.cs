using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class MemberAuthSettings : IAuthSettings
    {
        private readonly string publicKey;
        private readonly string privateKey;

        public MemberAuthSettings(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }

        public AuthenticationHeaderValue BuildHeader(string companyName)
        {
            return new AuthenticationHeaderValue(
                            "Basic", Convert.ToBase64String(
                                Encoding.ASCII.GetBytes($"{companyName}+{publicKey}:{privateKey}")));
        }
    }
}
