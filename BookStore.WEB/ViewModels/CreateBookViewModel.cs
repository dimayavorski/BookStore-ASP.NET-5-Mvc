using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание книги")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите цену книги")]
        [Range(0.00,1000.00,ErrorMessage = "Введено некорректное значение цены")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Выберите автора книги")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Выберите жанр книги")]
        public int CategoryId { get; set; }
        
        public SelectList Authors { get; set; }
        public SelectList Genres { get; set; }
    }
}