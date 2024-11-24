using Microsoft.AspNetCore.Identity;

namespace Sequoia.Authentication.Models;

public class User : IdentityUser
{
    public string ProfileId { get; set; }
}