using BookStore.BLL.DTO;
using BookStore.BLL.Interfaces;
using System.Web.Mvc;
using AutoMapper;
using BookStore.WEB.ViewModels;


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
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<BookDTO,BookViewModel>()).CreateMapper();
            var books = _bookService.GetBooks();
           
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
            var books = _bookService.GetBooks();
             return PartialView("ShowBooks", books);
        }

        public ActionResult Edit(int id)
        {
            var book = _bookService.GetBook(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, CreateBookViewModel>()).CreateMapper();
            var viewModel = mapper.Map<BookDTO, CreateBookViewModel>(book);
            viewModel.Authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            viewModel.Genres = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            return PartialView(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateBookViewModel,BookDTO>()).CreateMapper();
                var bookDTO = mapper.Map<CreateBookViewModel,BookDTO>(viewModel);
                _bookService.Update(bookDTO);
                var books = _bookService.GetBooks();

                return PartialView("ShowBooks", books);
                
            }
            else
            {
                ModelState.AddModelError("","Данные заполнены неверно");
            }
            viewModel.Authors = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            viewModel.Genres = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            return PartialView("Edit", viewModel);

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