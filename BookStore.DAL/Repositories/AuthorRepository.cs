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
    public class AuthorRepository : IAuthorRepository<Author>
    {
        private BookContext db;
        public AuthorRepository(BookContext context)
        {
            db = context;
        }
        public IEnumerable<Author> GetAll()
        {
            return db.Authors.ToList();
        }
    }
}
