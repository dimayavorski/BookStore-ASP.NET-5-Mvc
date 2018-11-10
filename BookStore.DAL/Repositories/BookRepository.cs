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
    public class BookRepository : IBookRepository
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

        public int Delete(int Id)
        {
            Book book = db.Books.Find(Id);
            if (book != null)
            {
                db.Books.Remove(book);
            }

            return book.Id;
        }

        public IEnumerable<Book> Find(string searchString)
        {
            return db.Books.Where(b => b.Name.Contains(searchString)).Include(b => b.Author).Include(b => b.Category).ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Where(b=>b.Id==id).Include(b=>b.Author).Include(b=>b.Category).FirstOrDefault();
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.Include(b=>b.Author).Include(b=>b.Category);
        }

        public void Update(Book item)
        {
            Book updatedBook = db.Books.Where(b => b.Id == item.Id).FirstOrDefault();
            if (updatedBook != null)
            {
                updatedBook.Name = item.Name;
                updatedBook.Price = item.Price;
                updatedBook.Description = item.Description;

            }
            db.Entry(updatedBook).State = EntityState.Modified;
        }        
    }
}
