using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.BLL.DTO;
using System.Web.Mvc;
using AutoMapper;
using BookStore.BLL.Interface;
using System.Threading.Tasks;
using BookStore.WEB.Models;

namespace BookStore.WEB.Controllers
{
    public class ShoppingCartController : Controller
    {
        
        IOrderService orderService;
        private readonly ShoppingCartFactory shoppingCartFactory;
        public ShoppingCartController(IOrderService service,ShoppingCartFactory factory)
        {
            orderService = service;
            shoppingCartFactory = factory;
        }
        public async Task<ActionResult> Index(string returnUrl,Controller controller)
        {

            var cartId = shoppingCartFactory.GetCart(HttpContext);
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = await orderService.GetAllCartItems(cartId.ShoppingCartId),
                returnUrl = returnUrl,
                CartTotal = await orderService.GetTotal(cartId.ShoppingCartId)
            };
            return View(viewModel);
        }

   
        
        public async Task<ActionResult> RemoveFromCart(int id)
        {
            var cartId = shoppingCartFactory.GetCart(this.HttpContext).ShoppingCartId;
            orderService.RemoveFromCart(id, cartId);
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = await orderService.GetAllCartItems(cartId),
                CartTotal = await orderService.GetTotal(cartId)
            };
            return PartialView("ShowCart", viewModel); 
            
        }
        public async Task<ActionResult> EmptyCart()
        {
            var cartId = shoppingCartFactory.GetCart(this.HttpContext).ShoppingCartId;
            var CartItems = await orderService.GetAllCartItems(cartId);
            if(CartItems.Count ==0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
            }
            await orderService.EmptyCart(cartId);
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = await orderService.GetAllCartItems(cartId),
                CartTotal = await orderService.GetTotal(cartId)
            };
            return PartialView("ShowCart",viewModel);
        }
        



    }
}