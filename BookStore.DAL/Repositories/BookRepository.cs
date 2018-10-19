using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private BookContext db;
        public BookRepository(BookContext context)
        {
            db = context;
        }
        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(int Id)
        {
            Book book = db.Books.Find(Id);
            if (book != null)
            {
                db.Books.Remove(book);
            }
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.Include(b=>b.Author).Include(b=>b.Category);
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        //public IEnumerable<Book> GetBooksByCategory(string category)
        //{
        //    return db.Books.Where(string)
        //}
        
    }
}
