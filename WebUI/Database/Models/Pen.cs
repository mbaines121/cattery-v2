using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Pen
    {
        [Key]
        public Guid PenId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public decimal CostPerNight { get; set; }

        public int MaxOccupancy { get; set; } = 1;

        public ICollection<PenBooking> PenBookings { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }

        //public virtual AspNetUser User { get; set; }

        public bool Deleted { get; set; }
    }
}
