using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitBE.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public UserRole Role { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public required string PhoneNumber { get; set; }

    }
}
