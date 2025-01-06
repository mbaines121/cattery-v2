using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class AnimalPenBooking
    {
        [Key]
        public Guid AnimalPenBookingId { get; set; }

        [ForeignKey("Animal")]
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

        [ForeignKey("PenBooking")]
        public Guid PenBookingId { get; set; }
        public virtual PenBooking PenBooking { get; set; }
    }
}
