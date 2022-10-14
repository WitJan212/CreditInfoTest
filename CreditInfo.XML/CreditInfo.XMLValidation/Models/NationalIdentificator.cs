namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class NationalIdentificator
    {
        [XmlElementAttribute("NationalID")]
        public string? NationalID;
    }
}
