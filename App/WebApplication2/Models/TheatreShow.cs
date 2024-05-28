using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class TheatreShow
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public DateTime ShowDate { get; set; }

        public string ImageUrl { get; set; }
    }
}
