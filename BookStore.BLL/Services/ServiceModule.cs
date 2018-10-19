using BookStore.DAL.Interfaces;
using Ninject.Modules;
using BookStore.DAL.Repositories; 
namespace BookStore.BLL.Services
{
    public class ServiceModule : NinjectModule
    {
        //private string connectionString;
        //public ServiceModule(string connection)
        //{
        //    connectionString = connection;
        //}
        //public override void Load()
        //{
        //    Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(connectionString);
        //}
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
