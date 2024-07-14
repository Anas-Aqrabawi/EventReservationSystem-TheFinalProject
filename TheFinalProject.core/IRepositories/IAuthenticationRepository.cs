using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;

namespace TheFinalProject.core.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task Register(UserDTO userDto);

        Task HallOwnerRegister(UserDTO userDto);

        Task<UserLoginDTO> Login(UserCredentailsDTO userCredentailsDto);
    }
}
