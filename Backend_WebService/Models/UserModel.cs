using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_WebService.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string FirstName { get; set; } = "";
        public string CityName { get; set; } = "";
        public int YearOfJoining { get; set; }
    }
}
