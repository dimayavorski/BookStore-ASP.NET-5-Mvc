using BookStore.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.Models
{
    public class ShoppingCartFactory
    {
      
        private readonly IOrderService orderService;

        public ShoppingCartFactory(IOrderService service)
        {
            orderService = service;
        }
        public ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart(orderService);
            cart.ShoppingCartId = cart.GetCardId(context);

            return cart;
        }
        // Helper method to simplify shopping cart calls
        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
    }
}