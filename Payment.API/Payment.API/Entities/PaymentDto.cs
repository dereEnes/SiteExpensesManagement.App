using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.API.Entities
{
    public class PaymentDto
    {
       
        public string UserId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public byte ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public short Cvv { get; set; }
        public decimal Price { get; set; }
        public int BillId { get; set; }
    }
}
