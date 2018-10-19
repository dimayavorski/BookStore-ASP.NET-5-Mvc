using BookStore.DAL.Entities;
using BookStore.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Book> Books { get; }
        IRepository<Category> Categories { get; }
        ICartRepository Carts { get; }
        void Save();
        Task SaveAsync();
    }
}
