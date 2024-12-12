using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorCSharpDev
{
    internal class Product
    {
         public String ProductName { get; set; }
         public decimal Price { get; set; } //jezeli w przyszlosci by sie pojawily produkty z groszami

        public Product(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public override string? ToString()
        {
            return $"{ProductName} - {Price} PLN";
        }
    }
}
