
namespace CookMaster.Models
{
    public class AdminUser : User
    {
        public override bool IsAdmin => true;
    }
}
