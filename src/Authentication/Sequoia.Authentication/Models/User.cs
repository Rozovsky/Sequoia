using Microsoft.AspNetCore.Identity;

namespace Sequoia.Authentication.Models
{
    // TODO: use generic primary key
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public List<string> Roles { get; set; }
    }
}
