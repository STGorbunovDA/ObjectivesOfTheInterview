using System.Collections.Generic;

namespace ConnTest.Infrastructure.Interfaces
{
    internal interface IGenerate
    {
        /// <summary> Генерация XML-выходных данных </summary>
        string GenerateXmlOutput(Dictionary<string, int> offsets);
    }
}
