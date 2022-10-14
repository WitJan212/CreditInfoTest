namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class SubjectRole
    {
        [XmlElementAttribute("CustomerCode")]
        public string? CustomerCode;

        [XmlElementAttribute("RoleOfCustomer")]
        public string? RoleOfCustomer;

        [XmlElementAttribute("GuaranteeAmount")]
        public MoneyType? GuaranteeAmount;
    }
}
