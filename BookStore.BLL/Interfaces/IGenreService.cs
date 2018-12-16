using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;

namespace BookStore.BLL.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreDTO> GetCategories();
        GenreDTO GetGenre(int id);
        void Update(GenreDTO genreDto);
        void DeleteGenre(int id);
        void CreateGenre(GenreDTO genreDto);
    }
    
}
