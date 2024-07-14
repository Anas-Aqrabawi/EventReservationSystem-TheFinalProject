using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Reservation
    {
        public decimal ReservationId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public string? ReservationNotes { get; set; }
        public decimal? UserId { get; set; }
        public decimal? StatusId { get; set; }
        public decimal? HallId { get; set; }

        public virtual Hall? Hall { get; set; }
        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
    }
}
