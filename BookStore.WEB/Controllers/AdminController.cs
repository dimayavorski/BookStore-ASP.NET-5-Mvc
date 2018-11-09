using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        //public ActionResult Main(string category)
        //{
        //    var books = bookService.GetBooks(category);
        //    if (Request.IsAjaxRequest())
        //    {
        //        return PartialView("ShowBooks", books);
        //    }
        //    return View(books);
        //}

        //public ActionResult Delete(int id)
        //{
        //    var books = bookService.GetBooks(null);
        //    return PartialView(books);
        //}
        //public ActionResult Edit(int id)
        //{
        //    var book = bookService.GetBook(id);
        //    return PartialView(book);
        //}
    }
}