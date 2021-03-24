using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface IauthorRepository
    {
        void Add(Author author);
        void Edit(Author author);
        void Delete(Author author);
        Author GetAuthorById(int id);
        Author GetAuthorByPopularity();
        IEnumerable<Author> GetAuthors();
        
    }
}
