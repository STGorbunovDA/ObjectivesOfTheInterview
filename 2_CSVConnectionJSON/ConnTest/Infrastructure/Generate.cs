using ConnTest.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace ConnTest.Infrastructure
{
    internal class Generate : IGenerate
    {
        public string GenerateXmlOutput(Dictionary<string, int> offsets)
        {

            StringBuilder stringBuilder = new();
            StringBuilder xmlBuilder = stringBuilder;

            xmlBuilder.AppendLine("<item Binding=\"Introduced\">");

            foreach (var offset in offsets)
            {
                string tag = offset.Key;
                int offsetValue = offset.Value;

                xmlBuilder.AppendLine("    <node-path" + "{{" + $"{tag}" + "}}" + "></node-path>");
                xmlBuilder.AppendLine("    <address" + "{{" + $"{offsetValue}" + "}}" + "></address>");
            }

            xmlBuilder.AppendLine("</item>");
            return xmlBuilder.ToString();
        }
    }
}
