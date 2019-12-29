using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaptop.Models
{
    [Serializable] //tuần tự hóa(gán vào session)
    public class ShoppingCartViewModel
    {
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}