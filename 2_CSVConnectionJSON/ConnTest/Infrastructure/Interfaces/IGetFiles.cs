namespace ConnTest.Infrastructure.Interfaces
{
    internal interface IGetFiles
    {
        /// <summary> Получение файлов json </summary>
        string GetJSON();

        /// <summary> Получение файлов csv </summary>
        string[] GetCSV();
    }
}
