using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.WEB.ViewModels
{
    public class AuthorViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "ФИО должно быть заполнено")]
        public string Name { get; set; }
    }
}