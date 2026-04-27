using BlazorApp.Configuration;
using BlazorApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorApp.Services;

public class CustomerService
{
    private readonly IMongoCollection<Customer> _customers;

    public CustomerService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        _customers = mongoDatabase.GetCollection<Customer>(mongoDbSettings.Value.CollectionName);
    }

    public async Task<List<Customer>> GetPagedAsync(int page, int pageSize)
    {
        return await _customers
            .Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task CreateAsync(Customer customer)
    {
        await _customers.InsertOneAsync(customer);
    }

    public async Task UpdateAsync(string id, Customer customer)
    {
        await _customers.ReplaceOneAsync(x => x.Id == id, customer);
    }

    public async Task DeleteAsync(string id)
    {
        await _customers.DeleteOneAsync(x => x.Id == id);
    }

}    

