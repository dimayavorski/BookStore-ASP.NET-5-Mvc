using BookStore.DAL.Interfaces;
using Ninject.Modules;
using BookStore.DAL.Repositories; 
namespace BookStore.BLL.Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
