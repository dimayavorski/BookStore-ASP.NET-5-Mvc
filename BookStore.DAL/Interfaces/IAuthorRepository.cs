using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IAuthorRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
