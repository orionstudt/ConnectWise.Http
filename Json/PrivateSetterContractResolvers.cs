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
            if (prop.Writable) { return prop; }

            prop.Writable = member.IsPropertyWithSetter();
            return prop;
        }
    }

    internal class PrivateSetterCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (prop.Writable) { return prop; }

            prop.Writable = member.IsPropertyWithSetter();
            return prop;
        }
    }

    internal static class MemberInfoExtensions
    {
        internal static bool IsPropertyWithSetter(this MemberInfo member)
        {
            var property = member as PropertyInfo;
            if (property == null) { return false; }
            return property.GetSetMethod(true) != null;
        }
    }
}
