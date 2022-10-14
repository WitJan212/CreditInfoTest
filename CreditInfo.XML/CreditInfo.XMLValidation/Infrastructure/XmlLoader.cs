using System.ComponentModel;
namespace CreditInfo.XmlValidation.Infrastructure
{
    using System.Xml.Linq;
    using CreditInfo.XmlValidation.Extensions;
    using CreditInfo.XmlValidation.XmlValidation;
    using CreditInfo.XmlValidation.Constants;
    using CreditInfo.BusinessLogic.Models;
    using System.Xml;

    using System.Xml.Serialization;

    public class XmlLoader
    {
        public void RetrieveAllElementsAndValidate(
            string xmlFilePath,
            int itemsPerBatch)
        {
            int batchSize = itemsPerBatch <= 0 ? ProcessingConstants.VALIDATE_XML_NODES_PER_BATCH_SIZE : itemsPerBatch;
            XmlReader xmlReader = XmlReader.Create(xmlFilePath);
            XmlNameTable nameTable = xmlReader.NameTable;
            XElement xmlElements = XElement.Load(xmlFilePath);

            // Lets process the elements in the separate thread. But no need to do it per one element.
            // Better do it on some bunch of elements...
            IEnumerable<IEnumerable<XElement>> batchedElements = xmlElements
                .Elements()
                .Chunk(batchSize);

            // foreach (IEnumerable<XElement> elementsInBatch in batchedElements)
            Parallel.ForEach(batchedElements, elementsInBatch =>
            {
                ValidateBatchElements(elementsInBatch, nameTable);
            });
        }

        private void ValidateBatchElements(
            IEnumerable<XElement> batchedElements,
            XmlNameTable nameTable)
        {
            XElementContractValidator xElementContractValidator = new XElementContractValidator();
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Contract";
            xRoot.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(Contract), xRoot);

            batchedElements.ForEach(element =>
            {
                if (xElementContractValidator.IsValid(element, nameTable))
                {
                    Console.WriteLine("Validating element.... TRUE");
                    // Todo: Store the verified to store - lock...

                    // Deserialize the Contract and validate on BL
                    Contract contract = (Contract)serializer.Deserialize(element.CreateReader());

                    if (contract == null)
                    {
                        Console.WriteLine("No Contract deserialized");
                    }
                    else
                    {
                        Console.WriteLine("Contract deserialized");
                    }

                    // Todo: Deserialize
                }
                else
                {
                    // Todo: Store the not valid items to the error log...
                    Console.WriteLine("Validating element.... False");

                }
            });
        }
    }
}