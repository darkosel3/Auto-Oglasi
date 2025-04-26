using MongoDB.Bson;
using CarAds.Models;

namespace CarAds.Services
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAllAds();
        Ad? GetAdById(int id);

        void AddAd(Ad ad);
        void EditAd(Ad updatedAd);
        void DeleteAd(Ad ad);
    }
}