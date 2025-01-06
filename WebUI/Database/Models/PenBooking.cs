using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class PenBooking
    {
        [Key]
        public Guid PenBookingId { get; set; }

        [ForeignKey("Pen")]
        public Guid PenId { get; set; }
        public virtual Pen Pen { get; set; }

        [ForeignKey("Booking")]
        public Guid BookingId { get; set; }
        public virtual Booking Booking { get; set; }

        public ICollection<AnimalPenBooking> AnimalPenBookings { get; set; } = new List<AnimalPenBooking>();
    }
}
