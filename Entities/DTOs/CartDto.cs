using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public Int16 Quantity { get; set; }
    }
}
