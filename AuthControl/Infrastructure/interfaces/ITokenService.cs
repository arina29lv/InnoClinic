using AuthControl.Domain.Entities;

namespace AuthControl.Infrastructure.interfaces
{
    public interface ITokenService
    {
        (string token, DateTime expiresUtc) CreateAccessToken(User user);
    }
}
