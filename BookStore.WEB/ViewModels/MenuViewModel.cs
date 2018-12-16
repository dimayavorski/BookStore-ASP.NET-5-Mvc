using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.BLL.DTO;

namespace BookStore.WEB.ViewModels
{
    public class MenuViewModel
    {
        public List<GenreDTO> Categories { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}