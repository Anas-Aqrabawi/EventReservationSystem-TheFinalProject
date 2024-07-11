using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public string? TestimonialContent { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? UserId { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual User? User { get; set; }
    }
}
