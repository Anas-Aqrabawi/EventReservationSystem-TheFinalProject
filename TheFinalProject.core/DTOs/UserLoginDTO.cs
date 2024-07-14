using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject.core.DTOs
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string? RoleName { get; set; }
    }
}
