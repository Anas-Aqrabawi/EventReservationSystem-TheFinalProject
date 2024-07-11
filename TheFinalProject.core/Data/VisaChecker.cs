using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class VisaChecker
    {
        public decimal VisaChecherId { get; set; }
        public decimal Cvc { get; set; }
        public string CardHolderName { get; set; } = null!;
        public decimal? Balance { get; set; }
        public decimal CardNumber { get; set; }
    }
}
