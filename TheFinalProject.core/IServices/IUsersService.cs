using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;

namespace TheFinalProject.core.IServices
{
    public interface IUsersService
    {
        Task<List<UserInfoDTO>> GetAllRegisteredUsers();

        Task<List<UserInfoDTO>> GetAllHallOwners();

        Task<UserDTO> GetUserById(int id);

        Task UpdateUserInfo(UpdateUserDTO updateUser);

        Task<int> DeleteUserById(int id);
    }
}
