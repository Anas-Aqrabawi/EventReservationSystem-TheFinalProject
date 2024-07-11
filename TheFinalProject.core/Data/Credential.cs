using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Credential
    {
        public decimal CredentialId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
