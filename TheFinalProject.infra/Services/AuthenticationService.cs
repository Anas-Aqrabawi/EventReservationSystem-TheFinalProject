using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.IRepositories;
using TheFinalProject.core.IServices;

namespace TheFinalProject.infra.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authenticationRepository = authenticationRepository;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task HallOwnerRegister(UserDTO userDto)
        {
            await _authenticationRepository.HallOwnerRegister(userDto);
        }

        public async Task<string> Login(UserCredentailsDTO userCredentailsDto)
        {
            var result = await _authenticationRepository.Login(userCredentailsDto);

            if (result is null)
            {
                return null;
            }

            return _jwtTokenGenerator.GenerateToken(result);
        }


        public async Task Register(UserDTO userDto)
        {
            await _authenticationRepository.Register(userDto);
        }
    }
}
