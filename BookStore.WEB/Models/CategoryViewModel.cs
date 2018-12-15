using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}