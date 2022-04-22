using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Services
{
    public class CreditCardService
    {
        private readonly IBalanceService _balanceService;
        private readonly IMongoCollection<CreditCard> _creditCardCollection;

        public CreditCardService(
            IOptions<PaymentDbSettings> paymentDbSetting, IBalanceService balanceService)
        {
            var mongoClient = new MongoClient(
                paymentDbSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                paymentDbSetting.Value.DatabaseName);

            _creditCardCollection = mongoDatabase.GetCollection<CreditCard>(
                paymentDbSetting.Value.CreditCardCollectionName);
            _balanceService = balanceService;
        }
        public async Task<List<CreditCard>> GetAsync() =>
    await _creditCardCollection.Find(_ => true).ToListAsync();

        public async Task<CreditCard?> GetAsync(string userId) =>
            await _creditCardCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();

        public async Task CreateAsync(CreditCard creditCard)
        {
            if (await GetAsync(creditCard.UserId) is null)
            {
                await _creditCardCollection.InsertOneAsync(creditCard);
            }

            // kredi kartı eklendiğinde random bütçe girmek için
            Random rnd = new Random();
            Balance balance = new Balance
            {
                CardNumber = creditCard.CardNumber,
                Amount = rnd.Next(50, 800)
            };
            await _balanceService.CreateAsync(balance);
            
        }
           

        public async Task UpdateAsync(string userId, CreditCard updatedCard) =>
            await _creditCardCollection.ReplaceOneAsync(x => x.UserId == userId, updatedCard);

        public async Task RemoveAsync(string userId) =>
            await _creditCardCollection.DeleteOneAsync(x => x.UserId == userId);
    }
}
