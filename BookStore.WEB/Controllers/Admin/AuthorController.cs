using BookStore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.WEB.ViewModels;
using System.Threading.Tasks;

namespace BookStore.WEB.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class AuthorController : Controller
    {
        // GET: Author
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IGenreService _categoryService;

        public AuthorController(IBookService bookService, IAuthorService authorService, IGenreService categoryService)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _bookService = bookService;
        }
        public ActionResult GetAllAuthors()
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var authors =
                mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(_authorService.GetAllAuthors());
            //var authors = _authorService.GetAllAuthors();

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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorViewModel, AuthorDTO>()).CreateMapper();
                var authorDTO = mapper.Map<AuthorViewModel, AuthorDTO>(viewModel);
                _authorService.CreateAuthor(authorDTO);
                return RedirectToAction("Main", "Book");
            }

            return View(viewModel);
        }
        
        public ActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var authors =
                mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<AuthorViewModel>>(_authorService.GetAllAuthors());
            return PartialView("ShowAuthors", authors);
        }
        public ActionResult Edit(int id)
        {
            var authorDTO = _authorService.GetAuthor(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var viewModel = mapper.Map<AuthorDTO, AuthorViewModel>(authorDTO);
            return PartialView(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorViewModel, AuthorDTO>()).CreateMapper();
                var authorDTO = mapper.Map<AuthorViewModel, AuthorDTO>(viewModel);
                _authorService.Update(authorDTO);
                var mapperAuth = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
                var authors =
                    mapperAuth.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(_authorService.GetAllAuthors());
                return PartialView("ShowAuthors", authors);
               
            }
            
            return PartialView("Edit", viewModel);

        }
    }
}