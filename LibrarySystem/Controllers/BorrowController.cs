using LibrarySystem.Dtos;
using LibrarySystem.Dtos.BorrowDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService borrowservice;
        public BorrowController(IBorrowService borrowservice)
        {
            this.borrowservice = borrowservice;
        }

        [HttpPost("borrow")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> BorrowBook(BorrowBookDto borrowBookDto)
        {
                var result = await borrowservice.BorrowBookAsync(borrowBookDto.CustomerId, borrowBookDto.BookId);
                return Ok(new ApiResponse(true,"book borrowed successfully",result));
            
        }

        [HttpGet("calculate-fine/{borrowId}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> CalculateFine(int borrowId)
        {
            var fine = await borrowservice.CalculateFineAsync(borrowId);
            return Ok(new ApiResponse(true, "Fine calculated successfully", fine));

        }

        [HttpGet("active-borrows")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetActiveBorrows()
        {
            var borrows = await borrowservice.GetActiveBorrowsAsync();
            return Ok(new ApiResponse(true, "Active borrows retrieved successfully", borrows));
        }

        [HttpGet("by_book/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBorrowsByBookId(int bookId)
        {
            var borrows = await borrowservice.GetBorrowsByBookIdAsync(bookId);
            return Ok(new ApiResponse(true, "Borrows by book ID retrieved successfully", borrows));
        }

        [HttpGet("by_user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBorrowsByUserId(int userId)
        {
            var borrows = await borrowservice.GetBorrowsByUserIdAsync(userId);
            return Ok(new ApiResponse(true, "Borrows by user ID retrieved successfully", borrows));
        }
        [HttpGet("by_date_range")]
        [Authorize]
        public async Task<IActionResult> GetBorrowsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var borrows = await borrowservice.GetBorrowsByDateRangeAsync(startDate, endDate);
            return Ok(new ApiResponse(true, "Borrows by date range retrieved successfully", borrows));
        }

        [HttpGet("{borrowId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBorrowWithDetails(int borrowId)
        {
            var borrow = await borrowservice.GetBorrowWithDetailsAsync(borrowId);
            if (borrow == null)
                return NotFound(new ApiResponse(false, "Borrow not found"));
            return Ok(new ApiResponse(true, "Borrow details retrieved successfully", borrow));
        }

        [HttpGet("is_borrowed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IsBookBorrowedByUser([FromQuery] int userId, [FromQuery] int bookId)
        {
            var isBorrowed = await borrowservice.IsBookBorrowedByUserAsync(userId, bookId);
            return Ok(new ApiResponse(true, "Check completed successfully", isBorrowed));
        }

        [HttpPut("return/{borrowId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReturnBook(int borrowId)
        {
            var result = await borrowservice.ReturnBookAsync(borrowId);
            return Ok(new ApiResponse(true, "Book returned successfully", result));
        }
    }
}
