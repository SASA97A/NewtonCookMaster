
namespace CookMaster.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }

        public virtual bool IsAdmin => false;
    }
}
