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
       
        private IOrderService _orderService;
        private IAuthorService _authorService;
        private IGenreService _categoryService;
        public NavController(IOrderService orderService,IGenreService categoryService,IAuthorService authorService)
        {
            _categoryService = categoryService;
            _orderService = orderService;
            _authorService = authorService;
        }

        public ActionResult GetNav(string category = null, string author = null)
        {
            var categories = _categoryService.GetCategories();
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
 
    }
}