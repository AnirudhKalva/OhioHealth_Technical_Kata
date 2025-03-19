using MongoDB.Driver;
using Backend_WebService.Models;
using Microsoft.Extensions.Options;

namespace Backend_WebService.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<UserModel>(settings.Value.CollectionName);
        }

        public async Task SaveUser(UserModel user)
        {
            Console.WriteLine($"Saving User: {user.FirstName}, {user.CityName}, {user.YearOfJoining}");
            await _users.InsertOneAsync(user);
        }

        public async Task<UserModel?> RetrieveUser()
{
    var user = await _users.Find(_ => true)
                           .SortByDescending(u => u.Id) 
                           .Limit(1)
                           .FirstOrDefaultAsync();

    if (user == null)
        Console.WriteLine("No user found in MongoDB!");
    else
        Console.WriteLine($"Retrieved User: {user.FirstName}, {user.CityName}, {user.YearOfJoining}");

    return user;
}

    }
}
