using CarAds.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CarAds.Services
{
    public class AdService : IAdService
    {
        private readonly CarAdsDBContext _carAdsDbContext;

        public AdService(CarAdsDBContext carAdsDbContext)
        {
            _carAdsDbContext = carAdsDbContext;
        }

        public void AddAd(Ad ad)
        {
            _carAdsDbContext.Ads.InsertOne(ad);
        }

        public void DeleteAd(Ad ad)
        {
             var result = _carAdsDbContext.Ads.DeleteOne(a => a.Id == ad.Id);
            if (result.DeletedCount == 0)
                throw new ArgumentException("Ad not found.");
        }

        public void EditAd(Ad ad)
        {
            var filter = Builders<Ad>.Filter.Eq(a => a.Id, ad.Id);
            var result = _carAdsDbContext.Ads.ReplaceOne(filter, ad);
    
             if (result.MatchedCount == 0)
            {
                throw new ArgumentException("Ad to update cannot be found.");
            }
        }

        public IEnumerable<Ad> GetAllAds()
        {
            return _carAdsDbContext.Ads.Find(_ => true).ToEnumerable();
        }

        public Ad? GetAdById(ObjectId id)
        {
            return _carAdsDbContext.Ads.Find(a => a.Id == id).FirstOrDefault();
        }



    }
}