using Microsoft.EntityFrameworkCore;
using CarAds.Models;
using MongoDB.Driver;

namespace CarAds.Services
{
    public class CarAdsDBContext  //extend DB context for EF core
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<Ad> Ads { get; init; }



        //This allows EF core to configure DBContext specify DB provider and connection string
        public CarAdsDBContext(string connectionString, string databaseName){
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
            
            Ads = _database.GetCollection<Ad>("Ads");
        }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     //this is importat to set model relationships
        //     modelBuilder.Entity<ApplicationUser>();
        //     modelBuilder.Entity<Ad>();
        // }

    }

}