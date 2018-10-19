using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using AutoMapper;
using BookStore.WEB.Models;
using System.Threading.Tasks;

namespace BookStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        private readonly ShoppingCartFactory shoppingCartFactory;

        public HomeController(IOrderService service,ShoppingCartFactory factory)
        {
            orderService = service;
            shoppingCartFactory = factory;
        }
        public  ActionResult Index(string category, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.category = category;
            //ViewBag.page = page;
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            //var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(orderService.GetBooks(category));
            var books = orderService.GetBooks(category);
            //BookViewModel viewModel = new BookViewModel
            //{
            //    Books = orderService.GetBooks(category)
            //};
            ViewBag.Category = category;
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

    }
}
        
            //return View(books.ToPagedList(pageNumber,pageSize));
           
    
    

