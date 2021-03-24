using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Logger;
using OnlineBookstore.Models;
using OnlineBookstore.Services.Service.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var bookList = _bookService.GetBooks();
            if(bookList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.BooksListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoBooksInDB);
            }
            return View(bookList);
        }

        public JsonResult FillBooksDataTable()
        {
            var booklist = _bookService.GetBooks();
            return Json(new { data = booklist });
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            _logger.LogInformation(LoggerMessageDisplay.BookFoundDisplayDetails);

            if(book == null)
            {
                _logger.LogInformation(LoggerMessageDisplay.BookEditNotFound);
            }
            return View(book);
        }

        //GET: Books/Create

        public IActionResult Create()
        {
            var Categories = _categoryService.GetCategories();
            var Authors = _authorService.GetAuthors();
            var Publishers = _publisherService.GetPublishers();

            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Categories = GetSelectListItemsCategory(Categories);
            bookViewModel.Authors = GetSelectListItemsAuthors(Authors);
            bookViewModel.Publishers = GetSelectListItemsPublishers(Publishers);

            return View(bookViewModel);
        }

        private IEnumerable<SelectListItem> GetSelectListItemsCategory(IEnumerable<Category> categories)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select category..."
            });

            foreach (var element in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemsAuthors(IEnumerable<Author> authors)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select author..."
            });

            foreach (var element in authors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemsPublishers(IEnumerable<Publisher> publishers)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select publisher..."
            });

            foreach (var element in publishers)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Book/Edit
        [HttpGet]

        public IActionResult Edit(int Id)
        {
            var book = _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Edit(book);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        
        public IActionResult Delete(int Id)
        {
            var book = _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _bookService.Delete(Id);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else

                    return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}