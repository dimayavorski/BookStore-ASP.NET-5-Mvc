using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;

namespace BookStore.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookContext db;
        public AuthorRepository(BookContext context)
        {
            db = context;
        }

        public void Create(Author item)
        {
            db.Authors.Add(item);
        }

        public void Delete(int Id)
        {
            var author = db.Authors.Find(Id);
            if(!ReferenceEquals(author,null))
            {
                db.Authors.Remove(author);
            }
        }

        public Author Get(int id)
        {
            return db.Authors.Where(b => b.Id == id).FirstOrDefault();
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public void Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
