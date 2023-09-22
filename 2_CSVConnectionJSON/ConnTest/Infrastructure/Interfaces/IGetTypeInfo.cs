using System.Collections.Generic;

namespace ConnTest.Infrastructure.Interfaces
{
    internal interface IGetTypeInfo
    {
        /// <summary> Создание словаря типов </summary>
        Dictionary<string, Dictionary<string, string>> GetTypeInfoDictionary(string typeInfosJson);
    }
}
