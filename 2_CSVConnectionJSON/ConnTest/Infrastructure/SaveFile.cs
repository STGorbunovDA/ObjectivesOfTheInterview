using ConnTest.Infrastructure.Interfaces;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;

namespace ConnTest.Infrastructure
{
    internal class SaveFile : ISaveFile
    {
        static volatile SaveFile Class;
        static readonly object SyncObject = new();
        public static SaveFile GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        Class ??= new SaveFile();
                    }
                return Class;
            }
        }

        public bool SaveXml(string xmlOutput)
        {
            SaveFileDialog saveFile = new()
            {
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*",
                FileName = $"result"
            };

            if ((bool)saveFile.ShowDialog())
            {
                File.WriteAllText(saveFile.FileName, xmlOutput, Encoding.UTF8);
                return true;
            }
            else return false;     
        }
    }
}
