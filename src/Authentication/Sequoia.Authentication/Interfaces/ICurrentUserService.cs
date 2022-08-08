using Sequoia.Authentication.Models;

namespace Sequoia.Authentication.Interfaces
{
    public interface ICurrentUserService
    {
        public User User { get; }
    }
}
