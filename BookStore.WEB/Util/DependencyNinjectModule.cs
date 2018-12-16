using BookStore.BLL.Interface;
using BookStore.BLL.Services;
using System.Web.Mvc;
using BookStore.BLL.Interfaces;
using Ninject.Modules;

namespace BookStore.WEB.Util
{
    public class DependencyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IGenreService>().To<GenreService>();
            Bind<IUserService>().To<UserService>();
            Bind<IBookService>().To<BookService>();
            Kernel.Unbind<ModelValidatorProvider>();
        }
    }
}