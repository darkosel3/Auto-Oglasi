using MongoDB.Bson;
using CarAds.Models;

namespace CarAds.Services
{

    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int id);
    }
}