using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.API.Entities
{
    public class CreditCard
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string UserId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public byte ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public short Cvv { get; set; }
    }
}
