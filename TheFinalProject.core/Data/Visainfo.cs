using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Visainfo
    {
        public decimal PaymentId { get; set; }
        public decimal Cvc { get; set; }
        public string CardHolderName { get; set; } = null!;
        public decimal CardNumber { get; set; }
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
