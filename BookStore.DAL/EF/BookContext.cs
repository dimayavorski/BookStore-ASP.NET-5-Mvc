using BookStore.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookStore.DAL.EF
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails {get;set;}
        //public BookContext(string connectionString) : base(connectionString)
        //{

        //}
        public BookContext():base("BookContext")
        {
            //Database.SetInitializer(new EfDbInitializer());
            


        }

    }
}
