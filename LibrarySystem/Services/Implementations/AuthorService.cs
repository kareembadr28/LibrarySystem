using LibrarySystem.Dtos.AuthorDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IBookRepository bookRepository;
        public AuthorService(IAuthorRepository author,IBookRepository bookRepository)
        {
            authorRepository = author;
            this.bookRepository = bookRepository;
        }
        public async Task<BasicAuthorDto> CreateAuthorAsync(AddAuthorDto dto)
        {
            Author author = new Author
            {
                fullName = dto.Name,
                bio = dto.Biography,
                Books = new HashSet<Book>()
            };
          await authorRepository.AddAsync(author);
            return new BasicAuthorDto
            {
                Biography = dto.Biography,
                Name = dto.Name,
            };
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author=await authorRepository.GetWithhBooks(id);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            if(author.Books!=null&&author.Books.Any())
                throw new AuthorHasBooksException("this author has books you cant delete it");
            await authorRepository.DeleteAsync(author);

        }

        public async Task<IEnumerable<BasicAuthorDto>> GetAllAuthorsAsync()
        {
            var authors =await authorRepository.GetAllAsync();
            return authors.Select(a => new BasicAuthorDto
            {
                Biography = a.bio,
                Name = a.fullName,
            }).ToList();
        }

        public async Task<BasicAuthorDto> GetAuthorByIdAsync(int id)
        {
           var author =await  authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            return new BasicAuthorDto
            {
                Biography = author.bio,
                Name = author.fullName,
            };
        }

        public async Task<BasicAuthorDto> GetByFullNameAsync(string fullName)
        {
            var author =await authorRepository.GetByFullName(fullName);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            return new BasicAuthorDto
            {
                Biography = author.bio,
                Name = author.fullName,
            };
        }

        public async Task<AuthorWithBooksDto> GetWithBooksAsync(int id)
        {
            var author = await authorRepository.GetWithhBooks(id);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            return new AuthorWithBooksDto
            {
                Biography = author.bio,
                Name = author.fullName,
                BookTitles = author.Books.Select(b => b.title).ToList()
            };
        }

        public async Task<bool> IsAuthorOfBookAsync(int authorId, int bookId)
        {
            var author=await authorRepository.GetByIdAsync(authorId);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            var book = await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("this book is not exist");
            return await authorRepository.IsAuthorOfBook(authorId, bookId);
        }

        public async Task<BasicAuthorDto> UpdateAuthorAsync(int id, BasicAuthorDto dto)
        {
            var author =await authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new AuthorNotFoundException("this author is not exist");
            author.bio = dto.Biography;
            author.fullName = dto.Name;
            authorRepository.Update(author);
            await authorRepository.SaveChangesAsync();
            return new BasicAuthorDto
            {
                Biography = author.bio,
                Name = author.fullName,
            };
        }
    }
}
