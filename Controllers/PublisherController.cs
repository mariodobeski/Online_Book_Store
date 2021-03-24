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
    public class PublisherController : Controller
    {

        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            var publisher = _publisherService.GetPublishers();
            return View(publisher);
        }

        //GET: Publisher/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PublisherViewModel publisherViewModel)
        {
            var publisher = new Publisher();

            if (ModelState.IsValid)
            {
                publisher.Name = publisherViewModel.Name;
                publisher.Country = publisherViewModel.Country;

                _publisherService.Add(publisher);

                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        //GET: Publisher/Edit/5

        public IActionResult Edit(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        //GET: Publisher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Publisher publisher)
        {
            if(id  != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _publisherService.Edit(publisher);
                }

                catch(Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        //GET: Publisher/Details/5
        public IActionResult Details(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        //POST: Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _publisherService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}