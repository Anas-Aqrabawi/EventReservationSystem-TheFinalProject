using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;

namespace TheFinalProject.core.IServices
{
    public interface IAuthenticationService
    {
        Task Register(UserDTO userDto);

        Task HallOwnerRegister(UserDTO userDto);

        Task<string> Login(UserCredentailsDTO userCredentailsDto);
    }
}
