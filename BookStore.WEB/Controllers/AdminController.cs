using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.DTO;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Services;

namespace BookStore.WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin 
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;

        public AdminController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
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

        public ActionResult ListAllBooks(string category = null, string author = null)
        {
            var books = _bookService.GetBooks(category, author);


            return PartialView(books);
        }

        public JsonResult GetById(int id)
        {
            var book = _bookService.GetBook(id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            //var book = _bookService.GetBook(id);
            //var result = _bookService.DeleteBook(id);
            //var books 
            //return 
            return View();
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
        public ActionResult Edit(BookDTO book)
        {
            _bookService.Update(book);
            var books = _bookService.GetBooks(null,null);

            return PartialView("ShowBooks",books);
        }

        public ActionResult Create()
        {
            SelectList authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            SelectList categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.authors = authors;
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookDTO book)
        {
            _bookService.CreateBook(book);
            return RedirectToAction("Main");
        }
    }
}