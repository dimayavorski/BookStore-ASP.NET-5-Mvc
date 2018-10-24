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
    }
}
