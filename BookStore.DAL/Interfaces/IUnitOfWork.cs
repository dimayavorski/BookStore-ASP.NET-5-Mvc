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
        IBookRepository Books { get; }
        IGenreRepository Categories { get; }
        ICartRepository Carts { get; }
        IAuthorRepository Authors { get; }
        void Save();
        Task SaveAsync();
    }
}
