using BookStore.DAL.Interfaces;
using BookStore.DAL.Entities;
using System.Threading.Tasks;
using BookStore.DAL.EF;
using System.Linq;

namespace BookStore.DAL.Repositories
{
    public class OrderRepository
    {
        private readonly BookContext db;
        public OrderRepository(BookContext context)
        {
            db = context;
        }
        

    }
}
