using Microsoft.EntityFrameworkCore;
using CarAds.Models; // Importuj modele i Entiti Framework

namespace CarAds.Services
{
    public class CarAdsDBContext : DbContext //extend DB context for EF core
    {
        public DbSet<User> Users { get; init; } //Ef core will use this to perform crud operation on users

        public DbSet<Ad> Ads { get; init; }//Ef core will use this to perform crud operation on Ads


        //This allows EF core to configure DBContext specify DB provider and connection string
        public CarAdsDBContext(DbContextOptions options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //this is importat to set model relationships
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Ad>();
        }

    }

}