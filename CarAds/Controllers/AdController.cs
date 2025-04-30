using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using CarAds.Models;
using CarAds.Services;
using CarAds.ViewModels;  


namespace CarAds.Controllers{

    public class AdController : Controller{
        private readonly IAdService _AdService;
        // private readonly IUserService _UserService;

         public AdController(IAdService AdService){
            _AdService = AdService;
            // _UserService = UserService;
         }

         public IActionResult Index(){
            AdListViewModel viewModel = new (){Ads = _AdService.GetAllAds()};
            return View(viewModel);
         } 
         public IActionResult Add(){
            return View();
         }

         [HttpPost]
         public IActionResult Add(AdAddViewModel adAddViewModel){
            if(ModelState.IsValid){
                Ad newAd = new(){
                    Title = adAddViewModel.Ad.Title,
                    Brand = adAddViewModel.Ad.Brand,
                    Model = adAddViewModel.Ad.Model,
                    Year = adAddViewModel.Ad.Year,
                    Price = adAddViewModel.Ad.Price,
                    Kilometers = adAddViewModel.Ad.Kilometers,
                    Category = adAddViewModel.Ad.Category,
                    Description = adAddViewModel.Ad.Description,
                    Created = DateTime.Now
                };
                _AdService.AddAd(newAd);

                return RedirectToAction("Index");
                //Ukoliko je model podataka validan, dodaj novi oglas i vrati index stranicu
            }
            //Ako nije vrati istu stranicu da ponovo unese podatke
            return View(adAddViewModel);
         }

        public IActionResult Edit(ObjectId id){
            if(id == null || id == ObjectId.Empty){
                return NotFound();
            }
            var selectedAd = _AdService.GetAdById(id);
            return View(selectedAd);
        }

        [HttpPost]
        public IActionResult Edit(Ad ad){
            try{
                if(ModelState.IsValid){
                    _AdService.EditAd(ad);
                    return RedirectToAction("Index");
                }
                else{
                    return BadRequest();
                }
            }
            catch(Exception ex){
                ModelState.AddModelError("",$"Updating the add failed.Error:{ex}" );
            }

        return View(ad);
        }

        public IActionResult Delete(ObjectId id){
            if(id == ObjectId.Empty){
                return NotFound();
            }
            var selectedAd = _AdService.GetAdById(id);
            return View(selectedAd);
        }

            //   ViewData["ErrorMessage"] = "Deleting the restauarant failed, invalid ID!";
            //     return View();

        [HttpPost]
        public IActionResult Delete(Ad ad){
            if (ad.Id == ObjectId.Empty){
                ViewData["ErrorMessage"] = "Deleting the restauran failed, invalid ID";
                return View() ;
            }
            try{
                _AdService.DeleteAd(ad);
                TempData["AdDeleted"] = "Ad deleted successfully!";

                return RedirectToAction("Index");
            }catch(Exception ex){
                ViewData["ErrorMessage"] = $"Deleting the ad failed, please try again! Error:";
            }

            var selectedAd = _AdService.GetAdById(ad.Id);
            return View(selectedAd);
        }

    }
}