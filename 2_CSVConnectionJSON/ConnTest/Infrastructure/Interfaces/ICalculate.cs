using System.Collections.Generic;

namespace ConnTest.Infrastructure.Interfaces
{
    internal interface ICalculate
    {
        /// <summary> Вычисление смещений для каждого тега </summary>
        Dictionary<string, int> CalculateOffsets(string[] csvLines, Dictionary<string, Dictionary<string, string>> typeInfos);
    }
}
