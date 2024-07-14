using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Status
    {
        public Status()
        {
            Halls = new HashSet<Hall>();
            Reservations = new HashSet<Reservation>();
        }

        public decimal StatusId { get; set; }
        public string? Status1 { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
