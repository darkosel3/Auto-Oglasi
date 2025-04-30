using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace CarAds.Models
{
    [Collection("Ads")]
    public class Ad
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("brand")]
        public string Brand { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("kilometers")]
        public int Kilometers { get; set; }

        [BsonElement("category")]
        public int Category { get; set; }

        [BsonElement("description")]
        public int Description { get; set; }

        [BsonElement("created")]
        public DateTime Created { get; set; }

        [BsonElement("sellerId")]
        public ObjectId SellerId { get; set; }  // Referenca na User

        public Ad()
        {

        }
    }
}
