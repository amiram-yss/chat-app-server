using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat_app_web_api
{
    public class Chat
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        /*[Required]
        public List<Contact> contacts { get; set; } = new List<Contact>(2);*/
    }
}
