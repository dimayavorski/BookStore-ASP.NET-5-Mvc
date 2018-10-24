using System;
using System.Collections.Generic;
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
    public class BookService:IBookService
    {
        private IUnitOfWork Database;
        public BookService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<BookDTO> FindBooks(string searchName)
        {
                var books =  Database.Books.Find(searchName);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                    src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                    src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
                    return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);


            
        }
    }
}
