namespace Payment.API.Entities
{
    public class PaymentDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CreditCardCollectionName { get; set; } = null!;
        public string PaymentsCollectionName { get; set; } = null!;
        public string BalancesCollectionName { get; set; } = null!;
    }
}
