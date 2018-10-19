using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.DTO
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        public int BookId { get; set; }
        public BookDTO Book { get; set; }
        public int Count { get; set; }

        
    }
}
