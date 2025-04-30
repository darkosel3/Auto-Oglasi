using CarAds.Models;
using CarAds.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCore.Identity.Mongo;

using AspNetCore.Identity.Mongo.Model;
using MongoDB.Driver;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>(); // Where is the data?

// builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings")); // Remember this information so everyone can access the data!
builder.Services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole, Guid>(identityOptions => {
    // Regular identity options here if needed
    // identityOptions.Password.RequiredLength = 6;
}, mongoOptions => { 
    mongoOptions.ConnectionString = mongoDBSettings.AtlasURI + "/" + mongoDBSettings.DatabaseName;
});

// Add this before builder.Services.AddScoped<IAdService, AdService>()
builder.Services.AddScoped<CarAdsDBContext>(sp => 
{
    // Create the MongoDB context with the same connection as identity
    return new CarAdsDBContext(
        mongoDBSettings.AtlasURI + "/" + mongoDBSettings.DatabaseName,
        mongoDBSettings.DatabaseName);
});


builder.Services.AddScoped<IAdService,AdService>();


// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
