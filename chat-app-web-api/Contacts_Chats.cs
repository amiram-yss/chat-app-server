using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat_app_web_api
{
    public class Contacts_Chats
    {
        [Key]
        public int id { get; set; }
        [Required]
        //[ForeignKey("id")]
        //public string contact_id;
        //[Required]
        public Contact contact { get; set; }
        [Required]
        //[ForeignKey("id")]
        //public int chat_id { get; set; }
        //[Required]
        public Chat chat { get; set; }
    }
}
