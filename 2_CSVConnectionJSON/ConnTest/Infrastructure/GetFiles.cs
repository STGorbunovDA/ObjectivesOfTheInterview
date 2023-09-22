using ConnTest.Infrastructure.Interfaces;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ConnTest.Infrastructure
{
    class GetFiles : IGetFiles
    {
        static volatile GetFiles Class;
        static readonly object SyncObject = new();
        public static GetFiles GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        Class ??= new GetFiles();
                    }
                return Class;
            }
        }

        public string[] GetCSV()
        {
            OpenFileDialog openFile = new()
            {
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            openFile.ShowDialog();

            if (!String.IsNullOrWhiteSpace(openFile.FileName))
            {
                string[] csvLines = File.ReadAllLines(openFile.FileName);
                return csvLines.Skip(1).ToArray();
            }
            else MessageBox.Show("Вы не выбрали файл .csv который нужно добавить!", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);

            return Array.Empty<string>();
        }

        public string GetJSON()
        {
            OpenFileDialog openFile = new()
            {
                Filter = "json files (*.json)|*.json|All files (*.*)|*.*"
            };
            openFile.ShowDialog();

            if (!String.IsNullOrWhiteSpace(openFile.FileName))
            {
                string jsonContent = File.ReadAllText(openFile.FileName);
                return jsonContent;
            }
            else MessageBox.Show("Вы не выбрали файл .json который нужно добавить!", "Отмена",
                   MessageBoxButton.OK, MessageBoxImage.Information);

            return string.Empty;
        }
    }
}
