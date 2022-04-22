using Bestiary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bestiary.Services;

public class BestiaryServices
{
    private readonly IMongoCollection<Beast> _beastCollection;

    public BestiaryServices(IOptions<BestiaryDatabaseSettings> bestiaryDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bestiaryDatabaseSettings.Value.ConnectionString
        );
        
        var mongoDatabase = mongoClient.GetDatabase(
            bestiaryDatabaseSettings.Value.DatabaseName
        );

        _beastCollection = mongoDatabase.GetCollection<Beast>(
            bestiaryDatabaseSettings.Value.BestiaryCollectionName
            
        );
    }

    // Get all besats.
    public async Task<List<Beast>> GetBeastsAsync() 
        => await _beastCollection.Find(_ => true).ToListAsync();
    
    // Get only one beast by id.
    public async Task<Beast?> GetBeastAsync(string id)
        => await _beastCollection.Find(beast => beast.Id == id).FirstOrDefaultAsync();

    // Create a new beast on database.
    public async Task CreateAsync(Beast beast)
        => await _beastCollection.InsertOneAsync(beast);

    // Update one beast by id.
    public async Task UpdateAsync(string id, Beast updatedBeast)
        => await _beastCollection.ReplaceOneAsync(beast => beast.Id == id, updatedBeast);

    // Remove one beast by id.
    public async Task RemoveAsync(string id)
        => await _beastCollection.DeleteOneAsync(beast => beast.Id == id);
}