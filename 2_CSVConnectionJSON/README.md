# CandidateTest

**Тестовое задание для кандидатов на должность программиста ОРТПР ТН-ВВ**

***Предпочтительные технологии:** .NET, WPF*

Cписок задач:

1. Загрузить файл "Input.csv" и "TypeInfos.json" 
2.  Выполнить для каждой строки из Input.csv соединение с TypeInfos.json по типу.

**Пример:**

Для строки: root.SSN1.ZRP1.IL2.ZD1 указан тип ZD.
должно получиться:

| tag | offset |
| ------ | ------ |
| root.SSN1.ZRP1.IL2.ZD1.Cmd | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time01 | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time02 | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time03 | offset |
| ..... |  |
| root.SSN1.ZRP1.IL2.ZD1.Time11_in | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time12_in | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time13_in | offset |

где *offset* - это смещение от предыдушего на размер тип данных

| tag | offset |
| ------ | ------ |
| root.SSN1.ZRP1.IL2.ZD1.Cmd | 0 |
| root.SSN1.ZRP1.IL2.ZD1.Time01 | 4 |
| root.SSN1.ZRP1.IL2.ZD1.Time02 | 12 |
| root.SSN1.ZRP1.IL2.ZD1.Time03 | 20 |


3.  Сохранить полученые значение в формате XML по шаблону.


```xml
<item Binding="Introduced">
    <node-path>{{ tag }}</node-path>
    <address>{{ offset }}</address>
</item>
```


4. Реализовать графический интерфейс для загрузки *.csv файлов и выбора строк .csv необходимых для конвертации.

**Выполнение**

1. За загрузку отвечает [GetFiles] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/GetFiles.cs) имплементируя [IGetFiles] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/Interfaces/IGetFiles.cs)

2.1.  Произвожу создание словаря типов из TypeInfos.json [GetTypeInfo.GetTypeInfoDictionary] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/GetTypeInfo.cs) имплементируя [IGetTypeInfo] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/Interfaces/IGetTypeInfo.cs)

2.2. Здесь происходит вычисление смещений для каждого тега [Calculate.CalculateOffsets] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/Calculate.cs). Так-же создал костыль для возвращения типа значения [SizeOf.DataTypeInBytes] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/SizeOf.cs)

3.1. Генерация XML-выходных данных [Generate.GenerateXmlOutput] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/Generate.cs) имплементируя [IGenerate] (https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/Interfaces/IGenerate.cs)

3.2. Сохранение XML [SaveFile.SaveXml](https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Infrastructure/SaveFile.cs)

4. ![picture for Offset Converter](https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/source/1.png)

 View:[JsonCsvConnectionView](https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/Views/JsonCsvConnectionView.xaml)
 ViewModels [JsonCsvConnectionViewModel](https://github.com/STGorbunovDA/ObjectivesOfTheInterview/blob/main/2_CSVConnectionJSON/ConnTest/ViewModels/JsonCsvConnectionViewModel.cs)

