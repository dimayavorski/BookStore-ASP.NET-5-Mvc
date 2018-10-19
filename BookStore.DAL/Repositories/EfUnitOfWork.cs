using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Identity;
using BookStore.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private BookContext db;
        private BookRepository bookRepository;
        private CategoryRepository categoryRepository;
        private CartRepository cartRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
      

        public EfUnitOfWork()
        {
            db = new BookContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        }
        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

       

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }
        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public ICartRepository Carts
        {
            get { if (cartRepository == null)
                    cartRepository = new CartRepository(db);
                return cartRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        
        public void Save()
        {
           
            db.SaveChanges();
        }
    }
}
