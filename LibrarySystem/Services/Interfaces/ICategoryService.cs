using LibrarySystem.Dtos.BookDtos;
using LibrarySystem.Dtos.CategoryDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryDto dto);

        Task<bool> DeleteCategoryAsync(int id);

        Task<IEnumerable<CategoryWithBooksDto>> GetCategoriesWithBooksAsync();

        Task<CategoryDto> GetCategoryByIdAsync(int id);

        Task<CategoryDto> GetCategoryByNameAsync(string name);

        Task<CategoryWithBooksDto> GetCategoryWithBooksAsync(int categoryId);

        Task<bool> UpdateCategoryAsync(int id, CategoryDto dto);
    }
}
