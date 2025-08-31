using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public Task<Author> GetByFullName(string fullName);
        public Task<Author> GetWithhBooks(int id);
        public Task<Boolean> IsAuthorOfBook(int authorId, int bookId);
    }
}
