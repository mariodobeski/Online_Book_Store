using Microsoft.Extensions.Logging;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Logger;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services
{
    public class Bookservice : IBookService
    {
        private readonly IbookRepository _bookRepository;
        private readonly ILogger<Bookservice> _logger;

        public Bookservice(IbookRepository bookRepository, ILogger<Bookservice> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
            _logger.LogInformation(LoggerMessageDisplay.BookCreated);
        }

        public void Delete(int bookID)
        {
            _bookRepository.Delete(bookID);
        }

        public void Edit(Book book)
        {
            _bookRepository.Edit(book);
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.GetBookById(id);
            return result;
        }

        public IEnumerable<Book> GetBooks()
        {
            var result = _bookRepository.GetBooks();
            return result;
        }
    }
}
