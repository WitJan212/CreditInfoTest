namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class MoneyType
    {
        [XmlElementAttribute("Value")]
        public Decimal Value;

        [XmlElementAttribute("Currency")]
        public string? Currency;
    }
}
