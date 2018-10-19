using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BookContext db;
        
        public CartRepository(BookContext context)
        {
            db = context;
        }
        public async Task AddToCart(Book book,string Id)
        {
            var cartItem = await db.CartItems.SingleOrDefaultAsync(
                c => c.CartId == Id
                && c.BookId == book.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    BookId = book.Id,
                    CartId = Id,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
            
        }
        //Remove All CartItems From Db 
        public async Task Empty(string CartId)
        {
            var cartItems = await db.CartItems.Where(c => c.CartId == CartId).Include(b => b.Book).ToArrayAsync();
            db.CartItems.RemoveRange(cartItems);
        }

        public Task<List<CartItem>> GetAll(string Id)
        {
            return db.CartItems.Where(c => c.CartId == Id).Include(b => b.Book).ToListAsync();
        }

        public void Remove(int id, string CartId)
        {
            var cartItem = db.CartItems.SingleOrDefault(cart => cart.CartId == CartId && cart.CartItemId == id);
            var itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.CartItems.Remove(cartItem);
                }
            }
            
        }
        public async Task CreateOrder(Order order,string CartId)
        {
            
            decimal orderTotal = 0;
            var cartItems = await GetAll(CartId);
            foreach (var item in cartItems)
            {
                var book = await db.Books.SingleAsync(b => b.Id == item.BookId);
                var orderDetail = new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.OrderId,
                    UnitPrice = book.Price,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * book.Price);
                db.OrderDetails.Add(orderDetail);

            }
            order.Total = orderTotal;
            db.Orders.Add(order);
            await Empty(CartId);

        }
    }
}
