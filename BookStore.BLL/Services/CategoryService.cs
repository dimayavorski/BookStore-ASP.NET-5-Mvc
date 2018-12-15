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

       

        public void CreateGenre(CategoryDTO categoryDTO)
        {
            var genre = new Category { CategoryName = categoryDTO.CategoryName };
            database.Categories.Create(genre);
            database.Save();
        }

        public void DeleteGenre(int id)
        {
            database.Categories.Delete(id);
            database.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(database.Categories.GetAll());
        }

        public CategoryDTO GetGenre(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category,CategoryDTO> (database.Categories.Get(id));
        }

        public void Update(CategoryDTO categoryDTO)
        {
           var mapper =new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()).CreateMapper();
            var category =  mapper.Map<CategoryDTO, Category>(categoryDTO);
            database.Categories.Update(category);
            database.Save();

        }
    }
}
