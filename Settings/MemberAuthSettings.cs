using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class MemberAuthSettings : ICWAuthSettings
    {
        private string publicKey;
        private string privateKey;

        public MemberAuthSettings(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }

        public AuthenticationHeaderValue BuildHeader(string companyName)
        {
            return new AuthenticationHeaderValue(
                            "Basic", Convert.ToBase64String(
                                Encoding.ASCII.GetBytes(
                                    string.Format("{0}+{1}:{2}", companyName, publicKey, privateKey))));
        }
    }
}
