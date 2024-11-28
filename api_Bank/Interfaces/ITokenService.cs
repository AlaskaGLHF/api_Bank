using api_bank.Models;

namespace api_Bank.Interfaces
{
    public interface ITokenService
    {
       public string CreateToken(User user);
    }
}
