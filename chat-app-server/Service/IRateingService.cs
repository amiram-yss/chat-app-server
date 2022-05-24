using chat_app_server.Models;

namespace chat_app_server.Service
{
    public interface IRatingService
    {
        public ICollection<Rating> GetAll();
        public Task<IEnumerable<Rating>> GetAllAsync();
        public void Create(string Name, int Grade, string comment, DateTime Date);
        public Rating Get(string id);

        public Task<Rating> GetAsync(string id);
        public double GetAverge();
        public bool Edit(string id, Rating rating);
        public void Delete(string id);
    }
}
