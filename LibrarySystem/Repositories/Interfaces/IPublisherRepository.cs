using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<Publisher> GetByNameAsync(string name);

        Task<Publisher> GetWithBooksAsync(int publisherId);

        Task<bool> IsExistAsync(string name);

        Task<IEnumerable<Publisher>> GetAllWithBooksAsync();

    }
}
