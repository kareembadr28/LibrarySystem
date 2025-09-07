using LibrarySystem.Dtos;
using LibrarySystem.Dtos.AuthorDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAuthorAsync( AddAuthorDto dto)
        {
            var author =await authorService.CreateAuthorAsync(dto);
            return Created(string.Empty,
                new ApiResponse(true,"Author created successfully", author));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>deleteAuthorAsync(int id)
        {
            await authorService.DeleteAuthorAsync(id);
            return Ok(new ApiResponse(true, "Author deleted successfully"));
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAllAuthorsAsync()
        {
            var authors = await authorService.GetAllAuthorsAsync();
            return Ok(new ApiResponse(true, "Authors retrieved successfully", authors));
        }

        [HttpGet("getById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAuthorByIdAsync(int id)
        {
            var author =await authorService.GetAuthorByIdAsync(id);
            return Ok(new ApiResponse(true, "Author retrieved successfully", author));
        }

        [HttpGet("getByFullName/{fullName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getByFullNameAsync(string fullName)
        {
            var author = await authorService.GetByFullNameAsync(fullName);
            return Ok(new ApiResponse(true, "Author retrieved successfully", author));
        }

        [HttpGet("getWithBooks/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getWithBooksAsync(int id)
        {
            var author = await authorService.GetWithBooksAsync(id);
            return Ok(new ApiResponse(true, "Author with books retrieved successfully", author));
        }

        [HttpGet("isAuthorOfBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> isAuthorOfBookAsync(int authorId, int bookId)
        {
            var isAuthor = await authorService.IsAuthorOfBookAsync(authorId, bookId);
            return Ok(new ApiResponse(true, "Check completed successfully", isAuthor));
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateAuthorAsync(int id, BasicAuthorDto dto)
        {
            var author = await authorService.UpdateAuthorAsync(id, dto);
            return Ok(new ApiResponse(true, "Author updated successfully", author));
        }


    }
}
