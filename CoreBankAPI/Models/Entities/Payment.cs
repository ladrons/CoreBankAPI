using CoreBankAPI.Models.Entities.Common;

namespace CoreBankAPI.Models.Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }

        public int CardId { get; set; }

        public bool Result { get; set; }
        public int TransactionCode { get; set; }
        public DateTime PaymentDate { get; set; }


        public virtual Card Card { get; set; }
    }
}