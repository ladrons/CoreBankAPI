#nullable disable

namespace CoreBankAPI.DTOs
{
    public class PaymentDTO
    {
        public bool Result { get; set; }
        public int TransactionCode { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
