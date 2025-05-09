using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using CarAds.Models;

namespace CarAds.Services
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAllAds();
        Ad? GetAdById(ObjectId id);

        void AddAd(Ad ad);
        void EditAd(Ad updatedAd);
        void DeleteAd(Ad ad);
    }
}