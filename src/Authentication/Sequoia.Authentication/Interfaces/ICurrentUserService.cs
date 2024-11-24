using Sequoia.Authentication.Models;

namespace Sequoia.Authentication.Interfaces;

public interface ICurrentUserService
{
    public CurrentUser User { get; }
}