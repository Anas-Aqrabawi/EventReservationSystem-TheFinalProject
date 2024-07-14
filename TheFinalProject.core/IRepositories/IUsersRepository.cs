using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;

namespace TheFinalProject.core.IRepositories
{
    public interface IUsersRepository
    {
        Task<List<UserDTO>> GetAllRegisteredUsers();

        Task<List<UserDTO>> GetAllHallOwners();

        Task<UserDTO> GetUserById(int id);

        Task UpdateUserInfo(UpdateUserDTO updateUser);

        Task<int> DeleteUserById(int id);
    }
}
