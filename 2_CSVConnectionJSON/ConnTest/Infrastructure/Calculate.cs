using ConnTest.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConnTest.Infrastructure
{
    internal class Calculate : ICalculate
    {
        public Dictionary<string, int> CalculateOffsets(string[] csvLines, Dictionary<string, Dictionary<string, string>> typeInfos)
        {
            // Создаем новый экземпляр словаря, который будет содержать смещения для каждого свойства.
            Dictionary<string, int> offsets = new();

            // Переменная для вычисления смещения каждого свойства.
            int currentOffset = 0;

            foreach (string csvLine in csvLines)
            {
                string[] csvValues = csvLine.Split(';');
                string tag = csvValues[0];
                string type = csvValues[1];

                if (typeInfos.ContainsKey(type))
                {
                    Dictionary<string, string> properties = typeInfos[type];

                    int propertyCount = 0;

                    foreach (var property in properties)
                    {
                        if (currentOffset == 0)
                        {
                            offsets[tag + "." + property.Key] =
                                currentOffset + propertyCount * SizeOf.DataTypeInBytes(property.Value);
                            propertyCount++;
                        }
                        else
                        {
                            propertyCount++;
                            offsets[tag + "." + property.Key] =
                                currentOffset + propertyCount * SizeOf.DataTypeInBytes(property.Value);
                        }
                    }
                    currentOffset = offsets.LastOrDefault().Value;
                }
            }

            return offsets;
        }
    }
}
