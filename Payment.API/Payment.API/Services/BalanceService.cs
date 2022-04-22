using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Entities;
using System.Threading.Tasks;

namespace Payment.API.Services
{
    public interface IBalanceService
    {
        Task<bool> Withraw(string cardNo, decimal amount);
        Task UpdateAsync(Balance updatedBalance);
        Task CreateAsync(Balance balance);
    }
    public class BalanceService:IBalanceService
    {
        private readonly IMongoCollection<Balance> _balanceCollection;

        public BalanceService(
            IOptions<PaymentDbSettings> paymentDbSetting)
        {
            var mongoClient = new MongoClient(
                paymentDbSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                paymentDbSetting.Value.DatabaseName);

            _balanceCollection = mongoDatabase.GetCollection<Balance>(
                paymentDbSetting.Value.BalancesCollectionName);
        }
        public async Task<bool> Withraw(string cardNo, decimal amount)
        {
            var result = await _balanceCollection.Find(x => x.CardNumber == cardNo).FirstOrDefaultAsync();
            if (result is null || result.Amount < amount)
            {
                return false;
            }
            result.Amount -= amount;
            await UpdateAsync(result);
            return true;
        }
        public async Task UpdateAsync(Balance updatedBalance) =>
            await _balanceCollection.ReplaceOneAsync(x => x.CardNumber == updatedBalance.CardNumber, updatedBalance);
        public async Task CreateAsync(Balance balance)
        {
            await _balanceCollection.InsertOneAsync(balance);
        }
    }
}
