using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.DTO;

namespace BookStore.WEB.Models
{
    public class BookViewModel
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Category { get; set; }
        //public decimal Price { get; set; }
        //public string Author { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
        public Controller controller { get; set; }
    }
}