using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface IcategoryRepository
    {
        void Add(Category category);
        void Edit(Category category);
        void Delete(int id);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetCategories();
    }
}
