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
        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<Author,AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(database.Authors.GetAll());
        }
    }
}
