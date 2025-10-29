
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerMongoApi.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }

    




}
