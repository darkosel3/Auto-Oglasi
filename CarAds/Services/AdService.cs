
namespace CarAds.Services
{
    public class AdService : IAdService
    {
        private readonly CarAdsDbContex _carAdsDbContext;

        public AdsService(CarAdsDbContex carAdsDbContext)
        {
            _carAdsDbContext = carAdsDbContext;
        }

        public void AddAd(Ad ad)
        {
            _carAdsDbContext.Ads.Add(ad);

            _carAdsDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_carAdsDbContext.ChangeTracker.DebugView.LongView)

            _carAdsDbContext.SaveChanges();
        }

        public void DeleteAd DeleteAd(Ad ad)
        {
            var adToDelete = _carAdsDbContext.Ads.Where(a => a.Id == ad.Id).FirstOrDefault();

            if (adToDelete != null)
            {
                _carAdsDbContext.Ads.Remove(adToDelete);
                _carAdsDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_carAdsDbContext.ChangeTracker.DebugView.LongView);
                _carAdsDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The ad to delete cannot be found.");
            }
        }

        public void EditAd(Ad ad)
        {
            var adToUpdate = _carAdsDbContext.Ads.FirstOrDefault(a => a.Id == ad.Id);
            if (adToUpdate != null)
            {
                adToUpdate.Title = ad.Title;
                adToUpdate.Brand = ad.Brand
                adToUpdate.Model = ad.Model;
                adToUpdate.Year = ad.Year;
                adToUpdate.Price = ad.Price;
                adToUpdate.Kilometers = ad.Kilometers;
                adToUpdate.Category = ad.Category;
                adToUpdate.Description = ad.Description;
                adToUpdate.Created = ad.Created;

                _carAdsDbContext.Ads.Update(adToUpdate);

                _carAdsDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_carAdsDbContext.ChangesTracker.DebugView.LongView);
                _carAdsDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Ad to update cannot be found.");
            }
        }

        public IEnumerable<Ad> GetAllAds()
        {
            return _carAdsDbContext.Ads.OrderBy(a => a.Id).AsNoTracking().AsEnumerable<Ad>()
        }

        public Ad? GetAdById(ObjectId id)
        {
            return _carAdsDbContext.Ads.FirstOrDefault(ad => ad.Id == id);
        }



    }
}