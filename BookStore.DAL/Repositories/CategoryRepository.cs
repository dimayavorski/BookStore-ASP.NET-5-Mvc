using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.DAL.Interfaces;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using System.Collections;
using BookStore.DAL.EF;
using System.Data.Entity;

namespace BookStore.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private BookContext db;
        public CategoryRepository(BookContext context)
        {
            db = context;
        }
        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int Id)
        {
            var category = db.Categories.Find(Id);
            if (!ReferenceEquals(category, null))
            {
                db.Categories.Remove(category);
            }
        }

        public Category Get(int id)
        {
            return db.Categories.Where(c=>c.Id==id).FirstOrDefault();
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
