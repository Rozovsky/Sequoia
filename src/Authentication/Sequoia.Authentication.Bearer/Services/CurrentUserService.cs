using Microsoft.AspNetCore.Http;
using Sequoia.Authentication.Interfaces;
using Sequoia.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sequoia.Authentication.Bearer.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUser User { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            User = new CurrentUser
            {
                // get user's properties
                Id = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Sub),
                ProfileId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Sid),
                Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email),
                UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier),

                // get user's roles
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
