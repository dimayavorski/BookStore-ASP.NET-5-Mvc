using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;

namespace BookStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork database;

        public CategoryService(IUnitOfWork uow)
        {
            database = uow;
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(database.Categories.GetAll());
        }
    }
}
