using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public void Update(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
