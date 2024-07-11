using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Hall
    {
        public Hall()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public decimal HallId { get; set; }
        public string? HallName { get; set; }
        public decimal? FloorNumber { get; set; }
        public decimal? HallNumber { get; set; }
        public decimal? NumberOfTables { get; set; }
        public decimal? NumberOfChairs { get; set; }
        public decimal? HallCapacity { get; set; }
        public string? HallIdentity { get; set; }
        public string? HallLocation { get; set; }
        public decimal? Price { get; set; }
        public DateTime? HallAvailabilityDate { get; set; }
        public string? Services { get; set; }
        public string? Hall1ImagePath { get; set; }
        public string? Hall2ImagePath { get; set; }
        public string? Hall3ImagePath { get; set; }
        public string? Hall4ImagePath { get; set; }
        public string? Hall5ImagePath { get; set; }
        public string? Hall6ImagePath { get; set; }
        public string? Hall7ImagePath { get; set; }
        public string? Meridians { get; set; }
        public string? Latitude { get; set; }
        public bool? Isavailable { get; set; }
        public decimal? UserId { get; set; }
        public decimal? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
