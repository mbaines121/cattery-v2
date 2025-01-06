using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        public ICollection<PenBooking> PenBookings { get; set; } = new List<PenBooking>();

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }

        //public virtual AspNetUser User { get; set; }

        [Required]
        public bool Cancelled { get; set; } = false;

        [Required]
        public bool Deleted { get; set; } = false;
    }
}
