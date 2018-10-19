using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.DAL.Interfaces;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using System.Collections;
using BookStore.DAL.EF;

namespace BookStore.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private BookContext db;
        public CategoryRepository(BookContext context)
        {
            db = context;
        }
        public void Create(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
