using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> Find(string searchString);
    }
}
