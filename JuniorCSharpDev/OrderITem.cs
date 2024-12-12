using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorCSharpDev
{
    internal class OrderITem
    {

       public Product Product { get; set; }
       public int Quantity { get; set; }
       public OrderITem(Product product,int qunatity) {
            Product = product;
            Quantity = qunatity;
        }

        public decimal GetTotalPrice()
        {
            return Product.Price*Quantity;
        }
        public override string ToString()
        {
            return $"{Product.ProductName} x {Quantity} - {GetTotalPrice()} PLN";
        }
    }
}
