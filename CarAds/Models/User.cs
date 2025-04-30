using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.EntityFrameworkCore;

namespace CarAds.Models
{
    [Collection("Users")] //this tells ap what collection in DB we are using
    public class User : ApplicationUser
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
