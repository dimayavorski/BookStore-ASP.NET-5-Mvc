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
        private IBookRepository _bookRepository;
        private IGenreRepository _categoryRepository;
        private ICartRepository _cartRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IAuthorRepository _authorRepository;

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
        public IBookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(db);
                return _bookRepository;
            }
        }

        public IGenreRepository Categories
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new GenreRepository(db);
                return _categoryRepository;
            }
        }
        public IAuthorRepository Authors
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository(db);
                return _authorRepository;
            }
        }

        public ICartRepository Carts
        {
            get { if (_cartRepository == null)
                    _cartRepository = new CartRepository(db);
                return _cartRepository;
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
