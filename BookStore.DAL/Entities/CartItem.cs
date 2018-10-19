using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DAL.Entities
{
    public class CartItem
    {   [Key]
        public int CartItemId { get; set; }

        
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }
    }
}
