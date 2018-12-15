using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;

namespace BookStore.BLL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAllAuthors();
        void CreateAuthor(AuthorDTO authorDTO);
        void DeleteAuthor(int id);
        void Update(AuthorDTO authorDTO);
        AuthorDTO GetAuthor(int id);
    }
}
