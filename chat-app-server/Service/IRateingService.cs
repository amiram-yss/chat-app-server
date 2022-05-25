using chat_app_server.Models;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace chat_app_server.Service
{
    public interface IRatingService
    {
        public bool AllSetup(string id = null);
        public ICollection<Rating> GetAll();
        public Task<IEnumerable<Rating>> GetAllAsync();
        public void Create(Rating rating);
        public Task CreateAsync(Rating rating);
        public Rating Get(string id);
        public Task<Rating> GetAsync(string id);
        public double GetAverge();
        public void Edit(string id, Rating rating);
        public Task EditAsync(string id, Rating rating);
        public void Delete(string id);
        public void DeleteAsync(string id);
        public bool Exists (string id);
        public Task<bool> ExistsAsync(string id);
    }
}
