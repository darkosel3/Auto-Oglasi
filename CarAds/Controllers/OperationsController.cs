using CarAds.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CarAds.Controllers{
    public class OperationsController: Controller{
        private UserManager<ApplicationUser> userManager;

        public OperationsController(UserManager<ApplicationUser> userManager){
            this.userManager = userManager;
        }

        public IActionResult Create() => View(); //
        
        [HttpPost]
        public async Task<IActionResult> Create(User user){
            if(ModelState.IsValid){
              var appUser = new User // Use User instead of ApplicationUser
        {
            UserName = user.Name, 
            Email = user.Email,
            Password = user.Password 
        };
                IdentityResult result = await userManager.CreateAsync(appUser,user.Password); //hashes the password

                if(result.Succeeded){
                    ViewBag.Message = "User Created Successfully";
                }
                else{
                    foreach(IdentityError error in result.Errors){
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(user);
        }


    }
}