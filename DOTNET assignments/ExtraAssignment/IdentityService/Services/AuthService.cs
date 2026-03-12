using Microsoft.Extensions.Options;
using MongoDB.Driver;
using IdentityService.Models;

namespace IdentityService.Services
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
    }

    public class AuthService
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
            var mongoSettings = _configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _usersCollection = database.GetCollection<User>(mongoSettings.UsersCollectionName);
        }

        public async Task<User?> GetUserByUsername(string username) =>
            await _usersCollection.Find(x => x.Username == username).FirstOrDefaultAsync();

        public async Task CreateUser(User user) =>
            await _usersCollection.InsertOneAsync(user);
    }
}
