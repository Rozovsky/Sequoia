using Microsoft.AspNetCore.Identity;

namespace Sequoia.Authentication.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public List<string> Roles { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
