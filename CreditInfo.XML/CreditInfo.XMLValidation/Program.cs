using CreditInfo.XmlValidation.Constants;
using Infrastructure = CreditInfo.XmlValidation.Infrastructure;

Console.WriteLine("CreditInfo validating started.");

int processPatchSize;
string localPath = System.IO.Path.GetDirectoryName(
    System.Reflection.Assembly.GetExecutingAssembly().Location) ?? "";

if (args.Length == 0)
{
    Console.WriteLine("You have to set an xml file.");
    Environment.Exit(1);
}

string xmlFilePath = Path.Combine(localPath, args[0]);

try
{
    processPatchSize = Convert.ToInt32(args[1]);
}
catch
{
    processPatchSize = ProcessingConstants.VALIDATE_XML_NODES_PER_BATCH_SIZE;
}

if (!File.Exists(xmlFilePath))
{
    Console.WriteLine($"File '{xmlFilePath}' doesn't exist.");
    Environment.Exit(1);
}

Infrastructure.XmlLoader xmlLoader = new Infrastructure.XmlLoader();
xmlLoader.RetrieveAllElementsAndValidate(
    xmlFilePath,
    processPatchSize);




