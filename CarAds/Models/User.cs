using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.EntityFrameworkCore;

namespace CarAds.Models
{
    [Collection("Users")] //this tells ap what collection in DB we are using
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
    }
}
