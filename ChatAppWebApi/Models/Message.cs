using System.ComponentModel.DataAnnotations;

namespace ChatAppWebApi.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Contact Sender{ get; set; }
        [Required]
        public Chat Chat { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public DateTime SendingTime { get; set; }
    }
}
