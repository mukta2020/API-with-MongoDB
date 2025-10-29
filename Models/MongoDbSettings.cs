
namespace CustomerMongoApi.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CustomerCollection { get; set; }
    }
}
