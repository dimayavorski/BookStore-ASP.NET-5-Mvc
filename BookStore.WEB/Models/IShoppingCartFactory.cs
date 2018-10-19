using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.Models
{
    public interface IShoppingCartFactory
    {
        ShoppingCart GetCart(HttpContextBase context);
        ShoppingCart GetCart(Controller controller);
    }
}