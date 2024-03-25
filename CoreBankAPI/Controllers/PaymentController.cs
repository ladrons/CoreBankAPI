using CoreBankAPI.Context;
using CoreBankAPI.DTOs;
using CoreBankAPI.DTOs.External;
using CoreBankAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        readonly MyContext _context;

        public PaymentController(MyContext context)
        {
            _context = context;
        }

        //----------//----------//

        [HttpPost("AddCard")]
        public void AddCard(CardDTO card)
        {
            Card newCard = new Card
            {
                CardUsername = card.CardUsername,
                CardNumber = card.CardNumber,

                ExpirationMonth = card.ExpirationMonth,
                ExpirationYear = card.ExpirationYear,
                SecurityNumber = card.SecurityNumber,

                Limit = card.Limit,
                Balance = card.Balance,
            };
            _context.Cards.Add(newCard);
            _context.SaveChanges();
        }

        [HttpPost("ReceivePayment")]
        public PaymentResultDTO ReceivePayment(PaymentInformationDTO paymentInfo)
        {
            Card currentCard = _context.Cards.FirstOrDefault(c => c.CardNumber == paymentInfo.CardNumber)!;
            if (currentCard != null)
            {
                if (currentCard.ExpirationMonth == paymentInfo.ExpirationMonth && currentCard.ExpirationYear == paymentInfo.ExpirationYear)
                {
                    if (currentCard.SecurityNumber == paymentInfo.SecurityNumber)
                    {
                        if (currentCard.Balance >= paymentInfo.Amount)
                        {
                            SetBalance(currentCard, paymentInfo.Amount);

                            Random random = new Random();
                            int transactionCode = random.Next(100000, 999999);

                            Payment newPayment = new Payment()
                            {
                                Result = true,
                                TransactionCode = transactionCode,
                                PaymentDate = DateTime.Now,

                                Card = currentCard
                            };
                            _context.Payments.Add(newPayment);
                            _context.SaveChanges();

                            return CreatePaymentResultDTO(newPayment.Result, newPayment.TransactionCode);
                        }
                        else
                        {
                            //Limit yetersiz.
                            return CreatePaymentResultDTO(false, CreateTransactionCode());
                        }
                    }
                    else
                    {
                        //Güvenlik numarası hatalı.
                        return CreatePaymentResultDTO(false, CreateTransactionCode());
                    }
                }
                else
                {
                    //Son kullanma tarihleri uyuşmuyor.
                    return CreatePaymentResultDTO(false, CreateTransactionCode());
                }
            }
            else
            {
                //Kart bulunamadı.
                return CreatePaymentResultDTO(false, CreateTransactionCode());
            }            
        }

        private void SetBalance(Card currentCard, decimal amount)
        {
            currentCard.Balance -= amount;
            _context.SaveChanges();
        }
        private int CreateTransactionCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private PaymentResultDTO CreatePaymentResultDTO(bool result, int transactionCode)
        {
            return new PaymentResultDTO
            {
                Result = result,
                TransactionCode = transactionCode,
                PaymentDate = DateTime.Now
            };
        }
    }
}