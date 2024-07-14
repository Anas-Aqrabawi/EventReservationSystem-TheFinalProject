using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProject.core.DTOs;

namespace TheFinalProject.core.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserLoginDTO user);
    }
}
