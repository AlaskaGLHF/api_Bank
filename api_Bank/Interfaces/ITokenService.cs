using api_bank.Models;

namespace api_Bank.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
