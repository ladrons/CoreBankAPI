#nullable disable

namespace CoreBankAPI.DTOs.External
{
    public class PaymentInformationDTO
    {
        public string CardUsername { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string SecurityNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
