using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Britzzav4.Models
{
    public class User
    {
        [BsonElement("_id")]
        public ObjectId UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Function { get; set; }
    }
}
