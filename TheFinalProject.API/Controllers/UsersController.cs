using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.IServices;

namespace TheFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<int> DeleteUserById(int id)
        {
            return await _usersService.DeleteUserById(id);
        }

        [HttpGet]
        [Route("GetAllRegisteredUsers")]
        public async Task<List<UserInfoDTO>> GetAllRegisteredUsers()
        {
            return await _usersService.GetAllRegisteredUsers();
        }

        [HttpGet]
        [Route("GetAllHallOwners")]
        public async Task<List<UserInfoDTO>> GetAllHallOwners()
        {
            return await _usersService.GetAllHallOwners();
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            return await _usersService.GetUserById(id);
        }

        [HttpPut]
        public async Task UpdateUserInfo(UpdateUserDTO updateUser)
        {
            await _usersService.UpdateUserInfo(updateUser);
        }
    }
}
