using LibrarySystem.Dtos.BookDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Implementation;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IPublisherRepository publisherRepository;

       public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IPublisherRepository publisherRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.categoryRepository = categoryRepository;
            this.publisherRepository = publisherRepository;
        }
        public async Task<BookDetailsDto> AddBookAsync(AddBookDto bookdto)
        {
            var existingBook = await bookRepository.GetByISBNAsync(bookdto.ISBN);
            if (existingBook != null)
                throw new DuplicateBookException("A book with the same ISBN already exists");

            var author = await authorRepository.GetByIdAsync(bookdto.AuthorId);
            if (author == null)
                throw new AuthorNotFoundException("Author not found");
            var category = await categoryRepository.GetByIdAsync(bookdto.CategoryId);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            var publishers = new List<Publisher>();
            foreach (var publisherId in bookdto.PublisherIds)
            {
                var publisher = await publisherRepository.GetByIdAsync(publisherId);
                if (publisher == null)
                    throw new PublisherNotFoundException($"Publisher with id {publisherId} not found");
                publishers.Add(publisher);
            }

            var book = new Book
            {
                title = bookdto.Title,
                iSBN = bookdto.ISBN,
                publishedDate = DateTime.UtcNow,
                price = bookdto.Price,
                stock = bookdto.Stock,
                authorId = bookdto.AuthorId,
                CategoryId = bookdto.CategoryId,
                author = author,
                category = category,
                publishers = publishers
            };
            await bookRepository.AddAsync(book);
            await bookRepository.SaveChangesAsync();
            return new BookDetailsDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                AuthorName = author.fullName,
                CategoryName = category.name,
                PublisherNames = publishers.Select(p => p.name).ToList()


            };
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book =await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
           await bookRepository.DeleteAsync(book);
            await bookRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BasicBookDTO>> GetAllBooksAsync()
        {
            var Books = await bookRepository.GetAllAsync();
            return Books.Select(b => new BasicBookDTO
            {
                
                Title = b.title,
                ISBN = b.iSBN,
                Price = b.price,
                Stock = b.stock
            });

        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
           var book = await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return book;
        }

        public async Task<IEnumerable<BookWithAuthorDto>> GetBooksByAuthorAsync(int authorId)
        {
           var author =await authorRepository.GetByIdAsync(authorId);
            if (author == null)
                throw new AuthorNotFoundException("Author not found");
            var authoredBooks = await bookRepository.GetBooksByAuthorAsync(authorId);
            return authoredBooks.Select(book => new BookWithAuthorDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                AuthorName = author.fullName
            }).ToList();
        }

        public async Task<IEnumerable<BookWithCategoryDto>> GetBooksByCategoryAsync(int categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            var books = await bookRepository.GetBooksByCategoryAsync(categoryId);
            return books.Select(book=>new BookWithCategoryDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                CategoryName = category.name
            } );

        }

        public async Task<IEnumerable<BasicBookDTO>> GetBooksByPublisherAsync(int publisherId)
        {
            var publisher = await publisherRepository.GetByIdAsync(publisherId);
            if (publisher == null)
                throw new PublisherNotFoundException("Publisher not found");

            var books = await bookRepository.GetBooksByPublisherAsync(publisherId);

            var result = books.Select(book => new BasicBookDTO
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock
            }).ToList();

            return result;
        }


        public async Task<BasicBookDTO> GetByISBNAsync(string isbn)
        {
            var book = await bookRepository.GetByISBNAsync(isbn);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return new BasicBookDTO
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock
            };
        }

        public async Task<IEnumerable<BasicBookDTO>> GetByPublishedDateRangeAsync(DateTime first, DateTime second)
        {
            if (first > second)
                throw new InvalidDateRangeException("The first date must be earlier than the second date.");

            var books = await bookRepository.GetByPublishedDateRangeAsync(first, second);

            if (books == null || !books.Any())
                throw new BookNotFoundException("No books found in the given date range");

            return books.Select(b => new BasicBookDTO
            {
                Title = b.title,
                ISBN = b.iSBN,
                Price = b.price,
                Stock = b.stock
            }).ToList();
        }


        public async Task<BasicBookDTO> GetByTitleAsync(string title)
        {
            var book = await bookRepository.GetByTitleAsync(title);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return new BasicBookDTO
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock
            };
        }

        public async Task<BookWithAuthorDto> GetWithAuthorAsync(int bookId)
        {
            var book = await bookRepository.GetWithAuthorAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return new BookWithAuthorDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                AuthorName = book.author.fullName
            };
        }

        public async Task<Book> GetWithBorrowsAndPurchasesAsync(int bookId)
        {
           var book =await bookRepository.GetWithBorrowsAndPurchasesAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return book;
        }

        public async Task<BookWithCategoryDto> GetWithCategoryAsync(int bookId)
        {
            var book =await bookRepository.GetWithCategoryAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return new BookWithCategoryDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                CategoryName = book.category.name
            };
        }

        public async Task<BookWithPublishersDto> GetWithPublishersAsync(int bookId)
        {
            var book = await bookRepository.GetWithPublishersAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return new BookWithPublishersDto
            {
                Title = book.title,
                ISBN = book.iSBN,
                Price = book.price,
                Stock = book.stock,
                Publishers = book.publishers.Select(p => p.name).ToList()
            };
        }
        public async Task<bool> IsInStockAsync(int bookId)
        {
            var book = await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            return book.stock > 0;
        }

        public async Task<IEnumerable<BasicBookDTO>> SearchAsync(string searchTerm)
        {
            var books = await bookRepository.SearchAsync(searchTerm);
            if(books == null || !books.Any())
                throw new BookNotFoundException("No books found matching the search term");
            return books.Select(b => new BasicBookDTO
            {
                Title = b.title,
                ISBN = b.iSBN,
                Price = b.price,
                Stock = b.stock
            });
            
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existing = await bookRepository.GetByIdAsync(book.Id);
            if (existing == null)
                throw new BookNotFoundException("Book not found");

            bookRepository.Update(book);
            await bookRepository.SaveChangesAsync();
            return book;
        }

    }
}
