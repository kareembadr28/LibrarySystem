using LibrarySystem.Dtos;
using LibrarySystem.Dtos.CategoryDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(CategoryDto dto)
        {
            var createdCategory = await categoryService.CreateCategoryAsync(dto);
            return Created(string.Empty,new ApiResponse(true,"Category added successfully", createdCategory));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            return Ok(new ApiResponse(true, "Category deleted successfully", result));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCategoriesWithBooks()
        {
            var categories = await categoryService.GetCategoriesWithBooksAsync();
            return Ok(new ApiResponse(true, "Categories retrieved successfully", categories));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            return Ok(new ApiResponse(true, "Category retrieved successfully", category));
        }

        [HttpGet("byName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category =await categoryService.GetCategoryByNameAsync(name);
            return Ok(new ApiResponse(true, "Category retrieved successfully", category));
        }

        [HttpGet("with-books/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryWithBooks(int categoryId)
        {
            var category = await categoryService.GetCategoryWithBooksAsync(categoryId);
            return Ok(new ApiResponse(true, "Category with books retrieved successfully", category));
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
         public async Task<IActionResult> UpdateCategory(int id, CategoryDto dto)
        {
            var result = await categoryService.UpdateCategoryAsync(id, dto);
            return Ok(new ApiResponse(true, "Category updated successfully", result));
        }
    }
}
