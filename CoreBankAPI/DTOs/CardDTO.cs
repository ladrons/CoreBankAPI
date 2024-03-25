#nullable disable

namespace CoreBankAPI.DTOs
{
    public class CardDTO
    {
        public string CardUsername { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string SecurityNumber { get; set; }

        public decimal Limit { get; set; }
        public decimal Balance { get; set; }
    }
}
