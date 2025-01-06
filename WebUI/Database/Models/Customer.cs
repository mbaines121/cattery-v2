using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [MaxLength(16)]
        public string Telephone { get; set; } = default!;

        [MaxLength(64)]
        public string Email { get; set; } = default!;

        public bool Deleted { get; set; } = false;

        public ICollection<Animal>? Animals { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }

        //public virtual AspNetUser User { get; set; }
    }
}
