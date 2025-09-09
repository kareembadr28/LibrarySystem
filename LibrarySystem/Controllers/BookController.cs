using LibrarySystem.Dtos;
using LibrarySystem.Dtos.BookDtos;
using LibrarySystem.Models;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook(AddBookDto bookdto)
        {
            var addedBook = await bookService.AddBookAsync(bookdto);
            return Created("",new ApiResponse(true, "book added successfully", addedBook));
        }

        [HttpDelete("Delete/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
             await bookService.DeleteBookAsync(bookId);
            return Ok(new ApiResponse(true, "book deleted successfully"));
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookService.GetAllBooksAsync();
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpGet("GetById/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await bookService.GetBookByIdAsync(bookId);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetByAuthor/{authorId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            var books = await bookService.GetBooksByAuthorAsync(authorId);
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpGet("GetByCategory/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            var books = await bookService.GetBooksByCategoryAsync(categoryId);
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpGet("GetByPublisher/{publisherId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBooksByPublisher(int publisherId)
        {
            var books = await bookService.GetBooksByPublisherAsync(publisherId);
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpGet("GetByISBN/{isbn}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetByISBN(string isbn)
        {
            var book = await bookService.GetByISBNAsync(isbn);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetByPublishedDateRange")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByPublishedDateRange([FromQuery] DateTime first, [FromQuery] DateTime second)
        {
            var books = await bookService.GetByPublishedDateRangeAsync(first, second);
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpGet("GetByTitle/{title}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var book = await bookService.GetByTitleAsync(title);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetWithAuthor/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetWithAuthor(int bookId)
        {
            var book = await bookService.GetWithAuthorAsync(bookId);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetWithBorrowsAndPurchases/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetWithBorrowsAndPurchases(int bookId)
        {
            var book = await bookService.GetWithBorrowsAndPurchasesAsync(bookId);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetWithCategory/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetWithCategory(int bookId)
        {
            var book = await bookService.GetWithCategoryAsync(bookId);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("GetWithPublishers/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetWithPublishers(int bookId)
        {
            var book = await bookService.GetWithPublishersAsync(bookId);
            return Ok(new ApiResponse(true, "book retrieved successfully", book));
        }

        [HttpGet("IsInStock/{bookId}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> IsInStock(int bookId)
        {
            var isInStock = await bookService.IsInStockAsync(bookId);
            return Ok(new ApiResponse(true, "stock status retrieved successfully", isInStock));
        }

        [HttpGet("Search/{searchitem}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> Search(string searchitem)
        {
            var books = await bookService.SearchAsync(searchitem);
            return Ok(new ApiResponse(true, "books retrieved successfully", books));
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var updatedBook = await bookService.UpdateBookAsync(book);
            return Ok(new ApiResponse(true, "book updated successfully", updatedBook));
        }



    }
}
