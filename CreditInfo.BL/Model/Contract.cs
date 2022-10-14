namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class Contract
    {
        [XmlElementAttribute("ContractCode")]
        public string ContractCode;

        [XmlElementAttribute("ContractData")]
        public ContractData ContractData;

        [XmlElementAttribute("Individual")]
        public List<Individual> Individuals;

        [XmlElementAttribute("SubjectRoles")]
        public List<SubjectRole> SubjectRoles;
    }
}
