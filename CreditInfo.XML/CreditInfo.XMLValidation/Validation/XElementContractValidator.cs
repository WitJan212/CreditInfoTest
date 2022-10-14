namespace CreditInfo.XmlValidation.XmlValidation
{
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using CreditInfo.XmlValidation.Enums;

    public class XElementContractValidator
    {
        private bool IsDocumentValid => this.validationResultStatus == XmlValidationResultType.Valid;

        private XmlValidationResultType validationResultStatus;

        public XElementContractValidator()
        {
            this.validationResultStatus = XmlValidationResultType.Error;
        }

        public bool IsValid(
            XElement element,
            XmlNameTable nameTable)
        {
            bool isValid = false;

            if (element != null)
            {
                try
                {
                    string documentString = this.TryWriteContractDocumentXml(element);
                    XmlDocument documentToValidate = new XmlDocument();
                    documentToValidate.LoadXml(documentString);

                    isValid = this.ValidateDocument(documentToValidate);
                }
                catch (Exception exception)
                {
                    // Console.WriteLine("Error: " + exception.Message);
                    exception.ToString();
                }
            }

            return isValid;
        }

        private bool ValidateDocument(XmlDocument document)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("http://creditinfo.com/schemas/Sample/Data", "Data.xsd");
            settings.ValidationType = ValidationType.Schema;

            // Todo: Check what is the original name of XML file?
            XmlReader reader = XmlReader.Create("Sample.xml", settings);
            document.Load(reader);

            ValidationEventHandler eventHandler = new ValidationEventHandler(this.ValidationEventHandler);
            this.validationResultStatus = XmlValidationResultType.Valid;
            document.Validate(eventHandler);

            return this.IsDocumentValid;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs eventArgs)
        {
            switch (eventArgs.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("\nError: {0}", eventArgs.Message);
                    this.validationResultStatus = XmlValidationResultType.Error;
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("\nWarning: {0}", eventArgs.Message);
                    this.validationResultStatus = XmlValidationResultType.Warning;
                    break;
            }
        }

        private string TryWriteContractDocumentXml(XElement contractElement)
        {
            string contractDocument = string.Empty;

            try
            {
                var settings = new XmlWriterSettings { Encoding = Console.OutputEncoding, Indent = true, OmitXmlDeclaration = true };

                // This should be taken from the input XSD document automatically...
                string versionLine = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                string batchLine = "<ci:Batch xmlns:ci=\"http://creditinfo.com/schemas/Sample/Data\"";
                string xsiLine = "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";
                string schemaLocationLine = "xsi:schemaLocation=\"http://creditinfo.com/schemas/Sample/Data Data.xsd\">";
                string endLine = "</ci:Batch>";

                using (var stringWriter = new StringWriter())
                {
                    stringWriter.WriteLine(versionLine);
                    stringWriter.WriteLine(batchLine);
                    stringWriter.WriteLine(xsiLine);
                    stringWriter.WriteLine(schemaLocationLine);

                    using (var writer = XmlWriter.Create(stringWriter, settings))
                    {
                        contractElement.WriteTo(writer);
                    }

                    stringWriter.WriteLine(endLine);
                    contractDocument = stringWriter.ToString();
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            return contractDocument;
        }
    }
}