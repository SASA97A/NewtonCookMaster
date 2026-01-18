using CookMaster.Models;

namespace CookMaster.Managers
{
    public static class UserManager
    {
        private static List<User> _users = new List<User>();
        public static User LoggedInUser { get; private set; }
      
        static UserManager()
        {
            _users.Add(new AdminUser { Username = "admin", Password = "password", Country = "Sweden" });
            _users.Add(new User { Username = "user", Password = "password", Country = "Sweden" });
        }

        public static bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                LoggedInUser = user;
                return true;
            }
            return false;
        }

        public static void Logout() => LoggedInUser = null;

        public static bool Register(string username, string password, string country)
        {
            if (_users.Any(u => u.Username == username)) return false;

            _users.Add(new User { Username = username, Password = password, Country = country });
            return true;
        }

        public static void UpdateUser(string newUsername, string newPassword, string newCountry)
        {
            if (LoggedInUser != null)
            {
                LoggedInUser.Username = newUsername;
                LoggedInUser.Password = newPassword;
                LoggedInUser.Country = newCountry;
            }
        }
    }
}
