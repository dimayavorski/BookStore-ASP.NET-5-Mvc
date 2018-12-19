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
    public class GenreService : IGenreService
    {
        private IUnitOfWork database;

        public GenreService(IUnitOfWork uow)
        {
            database = uow;
        }

       

        public void CreateGenre(GenreDTO genreDto)
        {
            var genre = new Genre { CategoryName = genreDto.CategoryName };
            database.Categories.Create(genre);
            database.Save();
        }

        public void DeleteGenre(int id)
        {
            database.Categories.Delete(id);
            database.Save();
        }

        public IEnumerable<GenreDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>,IEnumerable<GenreDTO>>(database.Categories.GetAll());
        }

        public GenreDTO GetGenre(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<Genre,GenreDTO> (database.Categories.Get(id));
        }

        public void Update(GenreDTO genreDto)
        {
           var mapper =new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>()).CreateMapper();
            var category =  mapper.Map<GenreDTO, Genre>(genreDto);
            database.Categories.Update(category);
            database.Save();

        }
    }
}
