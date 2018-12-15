using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.DTO;

namespace BookStore.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetGenre(int id);
        void Update(CategoryDTO categoryDTO);
        void DeleteGenre(int id);
        void CreateGenre(CategoryDTO categoryDTO);
    }
    
}
