namespace CarAds.Services{

    public class UserService : IUserService{

        private readonly CarAdsDbContex _carAdsDbContext;

        public UsersService(CarAdsDbContex carAdsDbContext){
            _carAdsDbContext = carAdsDbContext;
        }

        public void AddUser(User user){
            _carAdsDbContext.Users.Add(user);

            _carAdsDbContext.ChangeTracker.DettectChanges();
            Console.WriteLine(_carAdsDbContext.ChangeTracker.DebugView.LongView)

            _carAdsDbContext.SaveChanges(); 
        }

        public void DeleteUser(User user){

            var userToDelete = _carAdsDbContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();

           if(userToDelete != null){
            _carAdsDbContext.Users.Remove(userToDelete);
            _carAdsDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_carAdsDbContext.ChangeTracker.DebugView.LongView);
            _carAdsDbContext.SaveChanges();
           }
           else{
            throw new ArgumentException("The user to delete cannot be found");
           }

        }

        public void EditUser(User user){
            var userToUpdate = _carAdsDbContext.Users.FirstOrDefault(u=>u.Id == user.Id);
            if(userToUpdate != null){
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                userToUpdate.Phone = user.Phone;
                userToUpdate.Password = user.Password;

                _carAdsDbContext.Users.Update(userToUpdate);
                _carAdsDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_carAdsDbContext.ChangesTracker.DebugView.LongView);
                _carAdsDbContext.SaveChanges();

            } else{
                throw new ArgumentException("The user to update could not be found.");
            }
        }

        public IEnumerable<Users> GetAllUsers(){
            return _carAdsDbContext.Users.OrderBy(u=>u.Id).AsNoTracking().AsEnumerable<User>();
        }   
        User? GetUserById(int id){
            return _carAdsDbContext.Users.FirstOrDefault(u=>u.Id == id);
        }
    }
}