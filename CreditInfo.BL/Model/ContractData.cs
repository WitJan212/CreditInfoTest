namespace CreditInfo.BusinessLogic.Models
{
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class ContractData
    {
        [XmlElementAttribute("PhaseOfContract")]
        public string PhaseOfContract;

        [XmlElementAttribute("OriginalAmount")]
        public MoneyType OriginalAmount;

        [XmlElementAttribute("InstallmentAmount")]
        public MoneyType InstallmentAmount;

        [XmlElementAttribute("CurrentBalance")]
        public MoneyType CurrentBalance;

        [XmlElementAttribute("OverdueBalance")]
        public MoneyType OverdueBalance;

        [XmlElementAttribute("DateOfLastPayment")]
        public DateTime DateOfLastPayment;

        [XmlElementAttribute("NextPaymentDate")]
        public DateTime NextPaymentDate;

        [XmlElementAttribute("DateAccountOpened")]
        public DateTime DateAccountOpened;

        [XmlElementAttribute("RealEndDate")]
        public DateTime RealEndDate;
    }
}
