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
    public class GenreRepository : IGenreRepository
    {
        private BookContext db;
        public GenreRepository(BookContext context)
        {
            db = context;
        }
        public void Create(Genre item)
        {
            db.Genres.Add(item);
        }

        public void Delete(int Id)
        {
            var category = db.Genres.Find(Id);
            if (!ReferenceEquals(category, null))
            {
                db.Genres.Remove(category);
            }
        }

        public Genre Get(int id)
        {
            return db.Genres.Where(c=>c.Id==id).FirstOrDefault();
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public void Update(Genre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
