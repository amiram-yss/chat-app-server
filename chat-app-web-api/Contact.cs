using System.ComponentModel.DataAnnotations;

namespace chat_app_web_api
{
    public class Contact
    {
        [Key]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string server { get; set; }
        
        public string? last { get; set; }
        public DateTime? lastdate{ get; set; }
    }
}
