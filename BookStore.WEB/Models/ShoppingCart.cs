using BookStore.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WEB.Models
{
    public class ShoppingCart
    {
        private readonly IOrderService orderService;
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public ShoppingCart(IOrderService service)
        {
            orderService = service;
        }
       
        public string GetCardId(HttpContextBase context)
        {
            //if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            //{
            //    context.Session[CartSessionKey] = context.User.Identity.Name;
            //}
            //else
            //{
            //    Guid tempCardId = Guid.NewGuid();

            //    context.Session[CartSessionKey] = tempCardId.ToString();
            //}
            //return context.Session[CartSessionKey].ToString();
            var cartId = context.Session[CartSessionKey];
            if (cartId == null)
            {
                cartId = Guid.NewGuid().ToString();
                context.Session[CartSessionKey] = cartId;
            }
            return cartId.ToString();
        }
        
    }
}