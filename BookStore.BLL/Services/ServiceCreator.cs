using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Repositories;

namespace BookStore.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService()
        {
            return new UserService(new EfUnitOfWork());
        }
    }
}
