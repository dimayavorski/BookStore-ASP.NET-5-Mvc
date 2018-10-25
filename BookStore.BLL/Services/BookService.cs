using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.BLL.Infrastructure;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги","");
            var book = Database.Books.Get(id.Value);
            if (book == null)
                throw new ValidationException("Книга не найдена", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<Book, BookDTO>(Database.Books.Get(id.Value));

        }

        public IEnumerable<BookDTO> GetBooks(string category)
        {
            IEnumerable<Book> books;
            if (category != null)
            {
                books = Database.Books.GetAll().Where(b => b.Category.CategoryName == null || b.Category.CategoryName == category);

            }
            else
            {
                books = Database.Books.GetAll();

            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);
        }
    }
}
