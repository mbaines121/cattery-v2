using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Animal
    {
        public Animal()
        {
            AnimalPenBookings = new HashSet<AnimalPenBooking>();
        }

        public Guid AnimalId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string MedicalNotes { get; set; }

        public string DietaryNotes { get; set; }

        public Guid CustomerId { get; set; }

        public virtual ICollection<AnimalPenBooking> AnimalPenBookings { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
