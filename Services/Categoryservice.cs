using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Service.Interfaces
{
    public class Categoryservice : ICategoryService
    {
        public readonly IcategoryRepository _categoryRepository;

        public Categoryservice(IcategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public void Edit(Category category)
        {
            _categoryRepository.Edit(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _categoryRepository.GetCategories();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _categoryRepository.GetCategoryById(id);
            return result;
        }
    }
}
