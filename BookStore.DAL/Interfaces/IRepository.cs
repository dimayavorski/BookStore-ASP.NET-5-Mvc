using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int Id);
    }
}
