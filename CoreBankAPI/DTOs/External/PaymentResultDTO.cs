namespace CoreBankAPI.DTOs.External
{
    public class PaymentResultDTO
    {
        public bool Result { get; set; }
        public int TransactionCode { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
