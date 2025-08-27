using AuthControl.Domain.Entities;
using System.Globalization;

namespace AuthControl.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<bool> ExistByUsernameAsync(string username, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
