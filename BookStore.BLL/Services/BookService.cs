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
        private IUnitOfWork database;
        public BookService(IUnitOfWork uow)
        {
            database = uow;
        }

        public IEnumerable<BookDTO> FindBooks(string searchName)
        {
                var books =  database.Books.Find(searchName);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                    src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                    src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
                    return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);
            
        }
        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги","");
            var book = database.Books.Get(id.Value);
            if (book == null)
                throw new ValidationException("Книга не найдена", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<Book, BookDTO>(database.Books.Get(id.Value));

        }

        public IEnumerable<BookDTO> GetBooks(string category,string author)
        {
            IEnumerable<Book> books;
            if (category != null || author !=null)
            {
                books = database.Books.GetAll().Where(b=>b.Category.CategoryName == category || b.Author.Name ==author);

            }
            else
            {
                books = database.Books.GetAll();

            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);
        }

        public void DeleteBook(int id)
        {
            database.Books.Delete(id);
            database.Save();
            

        }

        public void Update(BookDTO book)
        {
            Book item = new Book
            {
                Id = book.Id,
                Name = book.Name,
                Price = book.Price,
                Description = book.Description,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
                
            };
            database.Books.Update(item);
            database.Save();
        }

        public void CreateBook(BookDTO book)
        {
            Book item = new Book
            {
                Name = book.Name,
                Price = book.Price,
                Description = book.Description,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId

            };
            database.Books.Create(item);
            database.Save();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(database.Books.GetAll());
        }
    }
}
