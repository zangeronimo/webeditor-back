using Domain.Models.Webeditor;

namespace Domain.Interfaces
{
    public interface ITokenProvider
    {
        string GenerateToken(User user, string secret);
    }
}