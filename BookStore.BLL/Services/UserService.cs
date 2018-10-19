using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;
using BookStore.BLL.Infrastructure;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace BookStore.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            var user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;

        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByNameAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser{Email = userDto.Email, UserName = userDto.Email};
                var result = await Database.UserManager.CreateAsync(user,userDto.Password);
                if(result.Errors.Count()>1)
                    return new OperationDetails(false,result.Errors.FirstOrDefault(),"");
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                await Database.SaveAsync();
                return  new OperationDetails(true,"Регистрация пройдена успешно","");
            }
            else
            {
                return  new OperationDetails(true,"Пользователь с таким логином уже существует","Email");
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole{ Name = roleName};
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
    }
}
