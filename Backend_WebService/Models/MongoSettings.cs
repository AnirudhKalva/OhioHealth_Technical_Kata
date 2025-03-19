namespace Backend_WebService.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";
    }
}
