namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class Individual
    {
        [XmlElementAttribute("CustomerCode")]
        public string CustomerCode;

        [XmlElementAttribute("FirstName")]
        public string FirstName;

        [XmlElementAttribute("LastName")]
        public string LastName;

        [XmlElementAttribute("Gender")]
        public string Gender;

        [XmlElementAttribute("DateOfBirth")]
        public DateTime DateOfBirth;

        [XmlElementAttribute("IdentificationNumbers")]
        public List<NationalIdentificator> NationalIdentificators;
    }
}
