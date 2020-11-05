using System.Threading.Tasks;//Task
using MyAPI.Core.Contexts;
using MyAPI.Core.Models.DbEntities;
using MyAPI.Core.Models.DTOs;

namespace MyAPI.Core.Services
{
    public class CategoryService : ICategoryService
    {
        //service always references context
        private readonly MyAppDbContext _context;

        public CategoryService(MyAppDbContext context)
        {
            _context = context;

        }

        public async Task CreateCategory(CategoryDTO cateogry)
        {
            Category newCategory = new Category()
            {
                //CategoryId is auto generated
                CategoryName = cateogry.CategoryName

            };
            _context.Categories.Add(newCategory);

            await _context.SaveChangesAsync();

            cateogry.CategoryId = newCategory.CategoryId;//Add CategoryId to DTO and return it
  
        }

    }

    public interface ICategoryService
    {
        Task CreateCategory(CategoryDTO category);

    }
}