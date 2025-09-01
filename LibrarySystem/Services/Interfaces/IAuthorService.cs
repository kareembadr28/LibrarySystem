using LibrarySystem.Dtos.AuthorDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<BasicAuthorDto> CreateAuthorAsync(AddAuthorDto dto);
        Task<BasicAuthorDto> UpdateAuthorAsync(int id, BasicAuthorDto dto);
        Task DeleteAuthorAsync(int id);
        Task<BasicAuthorDto> GetAuthorByIdAsync(int id);
        Task<IEnumerable<BasicAuthorDto>> GetAllAuthorsAsync();

        Task<BasicAuthorDto> GetByFullNameAsync(string fullName);
        Task<AuthorWithBooksDto> GetWithBooksAsync(int id);
        Task<bool> IsAuthorOfBookAsync(int authorId, int bookId);
    }
}
