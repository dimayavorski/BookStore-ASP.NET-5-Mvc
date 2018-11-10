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
        private IBookService bookService;
        public AdminController(IBookService service)
        {
            bookService = service;
        }
        public ActionResult Main()
        {
            return View();
        }

        public JsonResult ListAllBooks(string category = null, string author = null)
        {
            var books = bookService.GetBooks(category, author);
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var book = bookService.GetBook(id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var books = bookService.GetBook(id);
            var result = bookService.DeleteBook(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(BookDTO book)
        {
            
            bookService.Update(book);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}