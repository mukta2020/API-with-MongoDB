
using MongoDB.Driver;
using CustomerMongoApi.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomerMongoApi.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(IOptions<MongoDbSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.Value.CustomerCollection);
        }

        public async Task<List<Customer>> GetAllAsync() =>
            await _customers.Find(_ => true).ToListAsync();

        public async Task<Customer> GetAsync(string id) =>
            await _customers.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Customer customer) =>
            await _customers.InsertOneAsync(customer);

        public async Task UpdateAsync(string id, Customer customer) =>
            await _customers.ReplaceOneAsync(x => x.Id == id, customer);

        public async Task DeleteAsync(string id) =>
            await _customers.DeleteOneAsync(x => x.Id == id);
    }
}
