using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using chat_app_web_api;

namespace chat_app_web_api
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public string SenderId { get; set; }
        public Contact Sender { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}

