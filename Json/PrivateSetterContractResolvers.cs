using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contains Contract Resolvers for deserializing JSON into an object with private setters.
/// </summary>
namespace ConnectWise.Http.Json
{
    internal class PrivateSetterContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            
            if (!prop.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null) prop.Writable = property.GetSetMethod(true) != null;
            }

            return prop;
        }
    }

    internal static class CWJsonSerializer
    {
        public static JsonSerializerSettings PrivateSetters => new JsonSerializerSettings
        {
            ContractResolver = new PrivateSetterContractResolver()
        };
    }
}
