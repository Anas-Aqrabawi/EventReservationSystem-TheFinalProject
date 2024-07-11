using System;
using System.Collections.Generic;

namespace TheFinalProject.core.Data
{
    public partial class Feedback
    {
        public decimal FeedbackId { get; set; }
        public string? FeedbackContent { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? UserId { get; set; }
        public decimal? HallId { get; set; }

        public virtual Hall? Hall { get; set; }
        public virtual User? User { get; set; }
    }
}
