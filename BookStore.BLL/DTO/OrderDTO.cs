using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.DTO
{
    public class OrderDTO
    {
        public System.DateTime OrderDate { get; set; }
      
        public string UserName { get; set; }
   
        public string FirstName { get; set; }
  
        public string LastName { get; set; }
        
        public string Address { get; set; }
       
        public string City { get; set; }
        


        public string Phone { get; set; }
       

        public string Email { get; set; }

    }
}
