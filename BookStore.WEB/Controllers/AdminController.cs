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
        
        public AdminController(IBookService bookService,IAuthorService authorService,ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _bookService = bookService;
        }
        public ActionResult Main()
        {
            SelectList authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            SelectList categories = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.authors = authors;
            ViewBag.categories = categories;
            return View();
        }

        public JsonResult ListAllBooks(string category = null, string author = null)
        {
            var books = _bookService.GetBooks(category, author);
           
           
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var book = _bookService.GetBook(id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var books = _bookService.GetBook(id);
            var result = _bookService.DeleteBook(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(BookDTO book)
        {
            
            _bookService.Update(book);
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(BookDTO book)
        {
            _bookService.CreateBook(book);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}