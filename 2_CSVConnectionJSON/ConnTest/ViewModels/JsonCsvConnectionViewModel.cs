using ConnTest.Infrastructure;
using ConnTest.Infrastructure.Interfaces;
using ConnTest.ViewModels.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ConnTest.ViewModels
{
    internal class JsonCsvConnectionViewModel : ViewModelBase
    {
        Dictionary<string, Dictionary<string, string>> typeInfos;

        public ICommand AddJsonCsv { get; }
        IGetFiles GetFiles { get; }
        IGetTypeInfo GetTypeInfo { get; }
        ICalculate Сalculate { get; }
        IGenerate Generate { get; }
        ISaveFile SaveFile { get; }

        public JsonCsvConnectionViewModel()
        {
            AddJsonCsv = new ViewModelCommand(ExecuteAddJsonCsvCommand);
            GetFiles = new GetFiles();
            GetTypeInfo = new GetTypeInfo();
            Сalculate = new Calculate();
            Generate = new Generate();
            SaveFile = new SaveFile();
        }

        void ExecuteAddJsonCsvCommand(object obj)
        {
            string[] inputCsvLines = GetFiles.GetCSV();
            string typeInfosJsonContent = GetFiles.GetJSON();

            Dictionary<string, Dictionary<string, string>> typeInfos = GetTypeInfo.GetTypeInfoDictionary(typeInfosJsonContent);

            Dictionary<string, int> offsets = Сalculate.CalculateOffsets(inputCsvLines, typeInfos);

            string xmlOutput = Generate.GenerateXmlOutput(offsets);

            if(SaveFile.SaveXml(xmlOutput))
                MessageBox.Show("Успешно", "Отлично", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Неуспешно", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
