using LibrarySystem.Dtos.BookDtos;
using LibrarySystem.Dtos.CategoryDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto dto)
        {
            Category category = new Category
            {
                name = dto.name,
                description = dto.description
            };
            await categoryRepository.AddAsync(category);
            await categoryRepository.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            var categoryWithBooks = await categoryRepository.GetWithBooksAsync(id);
            if (categoryWithBooks != null && categoryWithBooks.Books.Any())
                throw new CategoryHasBooksException("Cannot delete category with associated books");
            await categoryRepository.DeleteAsync(category);
            await categoryRepository.SaveChangesAsync();

            return true;
        }




        public async Task<IEnumerable<CategoryWithBooksDto>> GetCategoriesWithBooksAsync()
        {
            var categories = await categoryRepository.GetCategoriesWithBooksAsync();
            return categories.Select(c => new CategoryWithBooksDto
            {
                Name = c.name,
                Description = c.description,
                BooksNames = c.Books.Select(b => b.title)
               .ToList()

            }).ToList();
        }


        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
          var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            return new CategoryDto
            {
                name = category.name,
                description = category.description
            };

        }

        public async Task<CategoryDto> GetCategoryByNameAsync(string name)
        {
            var category = await categoryRepository.GetByNameAsync(name);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            return new CategoryDto
            {
                name = category.name,
                description = category.description
            };
        }

        public async Task<CategoryWithBooksDto> GetCategoryWithBooksAsync(int categoryId)
        {
            var category =await categoryRepository.GetWithBooksAsync(categoryId);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            return new CategoryWithBooksDto
            {
                Name = category.name,
                Description = category.description,
                BooksNames = category.Books.Select(b => b.title).ToList()
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDto dto)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException("Category not found");
            category.name = dto.name;
            category.description = dto.description;
            categoryRepository.Update(category);
            await categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}
