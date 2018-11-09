using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using BookStore.BLL.Interfaces;
using BookStore.WEB.Models;
using BookStore.WEB.ViewModels;

namespace BookStore.WEB.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        private IOrderService _orderService;
        private IAuthorService _authorService;
        public NavController(IOrderService orderService,IAuthorService authorService)
        {
            _orderService = orderService;
            _authorService = authorService;
        }

        public ActionResult GetNav(string category = null, string author = null)
        {
            var categories = _orderService.GetCategories();
            var authors = _authorService.GetAllAuthors();
            MenuViewModel viewModel = new MenuViewModel
            {
                Authors = authors.ToList(),
                Categories = categories.ToList()
            };
            ViewBag.SelectedCategegory = category;
            ViewBag.SelectedAuthor = author;
            return PartialView(viewModel);
        }
        //public ActionResult RemoveFromCart(int id)
        //{
        //    var book = orderService.GetBook(id);
        //    if (book != null)
        //    {
        //        GetCart().RemoveLine(book);
        //    }
        //    return RedirectToAction("GetNav");
        //}
        //public Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        //cart = orderService.GetCart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}