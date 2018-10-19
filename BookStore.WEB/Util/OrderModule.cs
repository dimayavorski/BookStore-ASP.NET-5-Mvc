using BookStore.BLL.Interface;
using BookStore.BLL.Services;
using System.Web.Mvc;
using BookStore.BLL.Interfaces;
using Ninject.Modules;

namespace BookStore.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IUserService>().To<UserService>();
            Kernel.Unbind<ModelValidatorProvider>();
        }
    }
}