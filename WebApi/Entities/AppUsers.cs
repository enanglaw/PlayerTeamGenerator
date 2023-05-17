using Microsoft.AspNetCore.Identity;

namespace WebApi.Entities
{
    public class AppUsers:IdentityUser
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
