using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Models;
using OnlineBookstore.Services.Service.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public CategoryController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        //GET: Category/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            var category = new Category();
            if (ModelState.IsValid)
            {
                category.Name = categoryViewModel.Name;
                _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET: Category/Edit/5

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST: Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Category category)
        {
                if(id != category.Id)
                {
                    return NotFound();
                }

                if(ModelState.IsValid)
                {
                    try
                    {
                        _categoryService.Edit(category);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }

        //GET: Category/Details/5

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //GET: Authors/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public JsonResult CreateCategoryAJAX(string name)
        {
            var category = new Category();
            if(name != "" || name != null)
            {
                category.Name = name;
                _categoryService.Add(category);
            }
            return Json(category);
        }

    }
}