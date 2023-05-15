using Microsoft.AspNetCore.Http;
using Sequoia.Authentication.Interfaces;
using Sequoia.Authentication.Models;
using System.Security.Claims;

namespace Sequoia.Authentication.Bearer.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public User User { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            User = new User
            {
                // get auth server guid
                Id = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Sid),
                Login = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name),
                Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email),
                PhoneNumber = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone),

                // get auth server roles list
                Roles = new List<string>()
            };

            var userRoles = httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            if (userRoles != null)
            {
                User.Roles = userRoles;
            }
        }
    }
}
