using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;

namespace BookStore.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> FindBooks(string searchName);
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBooks(string category,string author);
        int DeleteBook(int id);
        void Update(BookDTO book);
        void CreateBook(BookDTO book);
    }
}
