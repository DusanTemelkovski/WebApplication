using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public User User { get; set; }

        public TheatreShow TheatreShow { get; set; }
    }
}
