using api_Bank.Dtos;
using api_Bank.Interfaces;
using api_bank.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bank.Repositories;

namespace api_Bank.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto.UserDtoRead>> GetAllAsyncUser()
        {
            var users = await _userRepository.GetAllAsyncUser();
            return users.Select(user => new UserDto.UserDtoRead
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate,
                CountryId = user.CountryId,
                Status = user.Status,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                ImagePath = user.ImagePath
            }).ToList();
        }

        public async Task<UserDto.UserDtoRead?> GetByIdAsyncUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsyncUser(id);
            if (user == null) return null;

            return new UserDto.UserDtoRead
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate,
                CountryId = user.CountryId,
                Status = user.Status,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                ImagePath = user.ImagePath
            };
        }

        public async Task<UserDto.UserDtoRead?> CreateAsyncUser(UserDto.UserDtoCreate userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Patronymic = userDto.Patronymic,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                HashPassword = userDto.HashPassword,
                CountryId = userDto.CountryId,
                Status = userDto.Status,
                ImagePath = userDto.ImagePath
            };

            var createdUser = await _userRepository.CreateUserAsyncUser(user);
            return new UserDto.UserDtoRead
            {
                UserId = createdUser.UserId,
                Name = createdUser.Name,
                Surname = createdUser.Surname,
                Patronymic = createdUser.Patronymic,
                Email = createdUser.Email,
                PhoneNumber = createdUser.PhoneNumber,
                CreatedDate = createdUser.CreatedDate,
                CountryId = createdUser.CountryId,
                Status = createdUser.Status,
                IsDeleted = createdUser.IsDeleted,
                DeletedAt = createdUser.DeletedAt,
                ImagePath = createdUser.ImagePath
            };
        }

        public async Task UpdateAsyncUser(int id, UserDto.UserDtoUpdate userDto)
        {
            var user = await _userRepository.GetUserByIdAsyncUser(id);
            if (user == null) throw new KeyNotFoundException("User not found.");

            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Patronymic = userDto.Patronymic;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.HashPassword = userDto.HashPassword;
            user.CountryId = userDto.CountryId;
            user.Status = userDto.Status;
            user.IsDeleted = userDto.IsDeleted;
            user.ImagePath = userDto.ImagePath;

            await _userRepository.UpdateUserAsyncUser(user);
        }

        public async Task<UserDto.UserDtoRead?> DeleteAsyncUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsyncUser(id);
            if (user == null) return null;

            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;

            await _userRepository.UpdateUserAsyncUser(user);
            return new UserDto.UserDtoRead
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate,
                CountryId = user.CountryId,
                Status = user.Status,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                ImagePath = user.ImagePath
            };
        }

        public async Task<UserDto.UserDtoRead?> CreateRegUserAsync(RegisterDto regDto)
        {
            var user = new User
            {
                Name = regDto.Name,
                Email = regDto.Email,
                HashPassword = regDto.Password,
                PhoneNumber = regDto.PhoneNumber
            };

            var createdUser = await _userRepository.CreateUserAsyncUser(user);
            return new UserDto.UserDtoRead
            {
                UserId = createdUser.UserId,
                Name = createdUser.Name,
                Surname = createdUser.Surname,
                Patronymic = createdUser.Patronymic,
                Email = createdUser.Email,
                PhoneNumber = createdUser.PhoneNumber,
                CreatedDate = createdUser.CreatedDate,
                CountryId = createdUser.CountryId,
                Status = createdUser.Status,
                IsDeleted = createdUser.IsDeleted,
                DeletedAt = createdUser.DeletedAt,
                ImagePath = createdUser.ImagePath
            };


        }
}
