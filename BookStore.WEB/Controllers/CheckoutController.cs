using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using BookStore.WEB.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.Infrastructure;

namespace BookStore.WEB.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private readonly IOrderService orderSerivce;
        private readonly ShoppingCartFactory shoppingCartFactory;
        public CheckoutController(IOrderService service,ShoppingCartFactory factory)
        {
            shoppingCartFactory = factory;
            orderSerivce = service;
        }
        [HttpGet]
        public ActionResult MakeOrder()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MakeOrder(OrderViewModel model)
        {
            var order = new OrderDTO();
            if (ModelState.IsValid)
            { 
                    TryUpdateModel(order);
                    order.OrderDate = DateTime.Now;
                    var cart = shoppingCartFactory.GetCart(this.HttpContext);
                    await orderSerivce.CreateNewOrder(order, cart.ShoppingCartId);
                    return RedirectToAction("Complete");
            }
           
                return View(model);
            
        }
        public ActionResult Complete(string name,string lname)
        {
            ViewBag.name = name;
            ViewBag.lname = lname;
            return View();
        }
    }
}