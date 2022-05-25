using System.ComponentModel.DataAnnotations;

namespace ChatAppWebApi.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public string Server { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Contact> Friends { get; set; }

        public Message LastMessage { get; set; }
    }
}
