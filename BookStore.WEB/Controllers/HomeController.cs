using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using AutoMapper;
using BookStore.WEB.Models;
using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.WEB.ViewModels;

namespace BookStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        IBookService bookService;
        private readonly ShoppingCartFactory shoppingCartFactory;

        public HomeController(IOrderService oService,IBookService bService,ShoppingCartFactory factory)
        {
            orderService = oService;
            shoppingCartFactory = factory;
            bookService = bService;
        }
        public ActionResult Index(int? id,string category, int? page,string searchName,string author)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IEnumerable<BookDTO> books;

            ViewBag.category = category;
            ViewBag.searchName = searchName;
            ViewBag.author = author;

            if (searchName == null)
                books = bookService.GetBooks(category,author);
            else
                books = bookService.FindBooks(searchName);
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var booksViewModel = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(books);


            if (Request.IsAjaxRequest())
            {
                var cart = shoppingCartFactory.GetCart(HttpContext);
                var addedBook = bookService.GetBook(id.Value);
                orderService.AddToCart(addedBook, cart.ShoppingCartId);
               

                return PartialView("BookSummary", booksViewModel.ToPagedList(pageNumber, pageSize));
            }
            
            return View(booksViewModel.ToPagedList(pageNumber,pageSize));
        }
        public async Task<ActionResult> AddToCart(int? id, int? page, string category,string author)
        {
            var cart = shoppingCartFactory.GetCart(HttpContext);
            var addedBook = bookService.GetBook(id.Value);
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            await orderService.AddToCart(addedBook, cart.ShoppingCartId);
            
            var books = bookService.GetBooks(category,author);

            return PartialView("BookSummary", books.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Autocomplete(string term)
        { 
                var books = bookService.FindBooks(term).Select(b => new {value = b.Name}).Distinct();
                return Json(books, JsonRequestBehavior.AllowGet);
        }

        

    }
}
        
           
           
    
    

