using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.Enums;
using TheFinalProject.core.IRepositories;
using TheFinalProject.core.IServices;

namespace TheFinalProject.infra.Services
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<int> DeleteUserById(int id)
        {
            return await _usersRepository.DeleteUserById(id);
        }

        public async Task<List<UserInfoDTO>> GetAllRegisteredUsers()
        {
            // Returns all registered users based USER enum filteration.
            // Converting From userDto into UserInfoDTO, so we can show only the specific data to the client side.
            var result = await _usersRepository.GetAllRegisteredUsers();

            var finalResult = result.Where(X => X.Roleid == (int)Roles.SystemRoles.User).Select(userDto => new UserInfoDTO
            {
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Gender = userDto.Gender,
                ImagePath = userDto.ImagePath,
                Email = userDto.Email,
                Password = userDto.Password
            }).ToList();

            return finalResult;
        }

        public async Task<List<UserInfoDTO>> GetAllHallOwners()
        {
           
            var result = await _usersRepository.GetAllHallOwners();

            var finalResult = result.Where(X => X.Roleid == (int)Roles.SystemRoles.Hall_Owner).Select(userDto => new UserInfoDTO
            {
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Gender = userDto.Gender,
                ImagePath = userDto.ImagePath,
                Email = userDto.Email,
                Password = userDto.Password
            }).ToList();

            return finalResult;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            return await _usersRepository.GetUserById(id);
        }

        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {
            await _usersRepository.UpdateUserInfo(updateUser);
        }
    }
}
