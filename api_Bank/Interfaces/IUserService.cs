using api_Bank.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_Bank.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto.UserDtoRead>> GetAllAsyncUser();
        Task<UserDto.UserDtoRead?> GetByIdAsyncUser(int id);
        Task<UserDto.UserDtoRead?> CreateAsyncUser(UserDto.UserDtoCreate userDto);
        Task UpdateAsyncUser(int id, UserDto.UserDtoUpdate userDto);
        Task<UserDto.UserDtoRead?> DeleteAsyncUser(int id);
    }
}
