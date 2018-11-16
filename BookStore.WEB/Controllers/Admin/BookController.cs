using BookStore.BLL.DTO;
using BookStore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.WEB.ViewModels;
using Ninject.Infrastructure.Language;

namespace BookStore.WEB.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {
        // GET: Admin 
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;

        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _bookService = bookService;
        }

        public ActionResult Main()
        {
            var books = _bookService.GetBooks(null, null);
            return View(books);
        }

        

        public ActionResult GetAllBooks()
        {
            var books = _bookService.GetBooks();
            return PartialView("ShowBooks", books);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);
            _bookService.DeleteBook(id);
            var books = _bookService.GetBooks(null, null);
            return PartialView("ShowBooks", books);

        }

        public ActionResult Edit(int id)
        {
            SelectList authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            SelectList categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.authors = authors;
            ViewBag.categories = categories;
            var book = _bookService.GetBook(id);

            return PartialView(book);
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                var books = _bookService.GetBooks(null, null);

                return PartialView("ShowBooks", books);
            }

            return PartialView("Edit", book);

        }

        public ActionResult Create()
        {

            CreateBookViewModel viewModel = new CreateBookViewModel
            {
                Authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name"),
                Genres = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName")
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BookDTO bookDTO = new BookDTO
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    CategoryId = viewModel.CategoryId,
                    Description = viewModel.Description,
                    AuthorId = viewModel.AuthorId
                };
               
                _bookService.CreateBook(bookDTO);
                return RedirectToAction("Main");
            }
            else
            {
                ModelState.AddModelError("","Введенные данные неккоректны");
            }

            return View(viewModel);
        }
    }
}