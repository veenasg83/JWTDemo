using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BooksApi.Models
{
    [BsonIgnoreExtraElements]
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PassWord { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

    }
}
