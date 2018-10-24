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
        public ActionResult Index(int? id,string category, int? page,string searchName)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.category = category;
            IEnumerable<BookDTO> books;
            ViewBag.searchName = searchName;
            if (searchName == null)
                books = orderService.GetBooks(category);
            else
                books = bookService.FindBooks(searchName);
            if (Request.IsAjaxRequest())
            {
                var cart = shoppingCartFactory.GetCart(HttpContext);
                var addedBook = orderService.GetBook(id.Value);
                orderService.AddToCart(addedBook, cart.ShoppingCartId);
               

                return PartialView("BookSummary", books.ToPagedList(pageNumber, pageSize));
            }
            
            return View(books.ToPagedList(pageNumber,pageSize));
        }
        public async Task<ActionResult> AddToCart(int? id, int? page, string category)
        {
            var cart = shoppingCartFactory.GetCart(HttpContext);
            var addedBook = orderService.GetBook(id.Value);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            await orderService.AddToCart(addedBook, cart.ShoppingCartId);
            BookViewModel viewModel = new BookViewModel
            {
                Books = orderService.GetBooks(category)
            };
            var books = orderService.GetBooks(category);

            return PartialView("BookSummary", books.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Autocomplete(string term)
        { 
                //var books = Boo.Where(a => a.Model.Contains(term))
                //    .Select(a => new { value = a.Model })
                //    .Distinct();
            var books = bookService.FindBooks(term).Select(b => new {value = b.Name}).Distinct();

                return Json(books, JsonRequestBehavior.AllowGet);
            
        }

    }
}
        
           
           
    
    

