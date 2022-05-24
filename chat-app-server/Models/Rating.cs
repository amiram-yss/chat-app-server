using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace chat_app_server.Models
{
    public class Rating
    {
        [Key]
        [Required]
        [MaxLength(20)]
        [Remote("IsNameAvailable", "Ratings", ErrorMessage = "Name is already taken.")]
        public string Name { get; set; }

        [Range(1,5)]
        [Required]
        public int Grade { get; set; }

        public string? Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
