using BookStore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.DTO;
using BookStore.WEB.ViewModels;

namespace BookStore.WEB.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class AuthorController : Controller
    {
        // GET: Author
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;

        public AuthorController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _bookService = bookService;
        }
        public ActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();


            return PartialView("ShowAuthors", authors);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AuthorDTO authorDTO = new AuthorDTO{ Id = viewModel.Id, Name = viewModel.Name};
                //TryUpdateModel(authorDTO);
                _authorService.CreateAuthor(authorDTO);
                return RedirectToAction("Main", "Book");
            }

            return View(viewModel);
        }
    }
}