using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Interfaces;
using AutoMapper;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork database;
        public AuthorService(IUnitOfWork uow)
        {
            database = uow;
        }

        public void CreateAuthor(AuthorDTO authorDTO)
        {
            Author author = new Author {Name = authorDTO.Name};
            database.Authors.Create(author);
            database.Save();
        }

        public void DeleteAuthor(int id)
        {
            database.Authors.Delete(id);
            database.Save();
        }

        public void Update(AuthorDTO authorDTO)
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<AuthorDTO,Author>()).CreateMapper();
            var author = mapper.Map<AuthorDTO, Author>(authorDTO);
            database.Authors.Update(author);
            database.Save();
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<Author,AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(database.Authors.GetAll());
        }

        public AuthorDTO GetAuthor(int id)
        {
           
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<Author,AuthorDTO>(database.Authors.Get(id));
        }
    }
}
