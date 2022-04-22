using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.API.Entities
{
    public class Balance
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
