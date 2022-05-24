using System.ComponentModel.DataAnnotations;

namespace chat_app_server.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Grade { get; set; }

        public string? Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
