using System.Collections.Generic;
using ConnTest.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;

namespace ConnTest.Infrastructure
{
    internal class GetTypeInfo : IGetTypeInfo
    {
        public Dictionary<string, Dictionary<string, string>> GetTypeInfoDictionary(string typeInfosJson)
        {
            JObject typeInfosObject = JObject.Parse(typeInfosJson);
            JArray typeInfosArray = (JArray)typeInfosObject["TypeInfos"];

            Dictionary<string, Dictionary<string, string>> typeInfos = new();

            foreach (var typeInfo in typeInfosArray)
            {
                string typeName = (string)typeInfo["TypeName"];
                var propertyInfos = (JObject)typeInfo["Propertys"];
                Dictionary<string, string> properties = propertyInfos.ToObject<Dictionary<string, string>>();
                typeInfos.Add(typeName, properties);
            }

            return typeInfos;
        }
    }
}
