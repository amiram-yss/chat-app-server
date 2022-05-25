namespace ChatAppWebApi.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public HashSet<string> Contacts { get; set; }

    }
}
