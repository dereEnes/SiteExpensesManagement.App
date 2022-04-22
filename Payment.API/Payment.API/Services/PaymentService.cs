using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Entities;
using System.Threading.Tasks;

namespace Payment.API.Services
{
    public interface IPaymentService
    {
        Task<bool> CreateAsync(PaymentDto paymentDto);
    }
    public class PaymentService:IPaymentService
    {
        private readonly IMongoCollection<PaymentDto> _paymentCollection;
        private readonly CreditCardService _creditCardService;
        private readonly IBalanceService _balanceService;

        public PaymentService(
            IOptions<PaymentDbSettings> paymentDbSetting, CreditCardService creditCardService, IBalanceService balanceService)
        {
            var mongoClient = new MongoClient(
                paymentDbSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                paymentDbSetting.Value.DatabaseName);

            _paymentCollection = mongoDatabase.GetCollection<PaymentDto>(
                paymentDbSetting.Value.PaymentsCollectionName);
            _creditCardService = creditCardService;
            _balanceService = balanceService;
        }

        public async Task<bool> CreateAsync(PaymentDto paymentDto)
        {
            await _creditCardService.CreateAsync(new CreditCard()
            {
                CardNumber = paymentDto.CardNumber,
                Cvv = paymentDto.Cvv,
                ExpiryMonth = paymentDto.ExpiryMonth,
                ExpiryYear = paymentDto.ExpiryYear,
                NameOnCard = paymentDto.NameOnCard,
                UserId = paymentDto.UserId
            });
            var result = await _balanceService.Withraw(paymentDto.CardNumber, paymentDto.Price);
            if (result)
            {
                await _paymentCollection.InsertOneAsync(paymentDto);
                return true;
            }
            return false;
            
        }
            
    }
}
