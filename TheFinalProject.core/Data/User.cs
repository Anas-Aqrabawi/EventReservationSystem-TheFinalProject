using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            Halls = new HashSet<Hall>();
            Reservations = new HashSet<Reservation>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Gender { get; set; }
        public string? ImagePath { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Credential? Credential { get; set; }
        public virtual Visainfo? Visainfo { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
