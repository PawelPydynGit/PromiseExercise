using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JuniorCSharpDev
{
    internal class Order
    {
        List<OrderITem> _list = new List<OrderITem>();


        public void AddProduct(Product product,int quantity)
        {
            var alreadyOnList = _list.Find(item => item.Product.ProductName.ToLower() == product.ProductName.ToLower());

            if (alreadyOnList != null)
                alreadyOnList.Quantity += quantity;
            
            else
                _list.Add(new OrderITem(product, quantity));
        }

        public void DeleteProduct(String productName,int quantityToDelete)
        {
            var toDelete = _list.Find(item => item.Product.ProductName.ToLower() == productName.ToLower());

            if(toDelete.Quantity >= quantityToDelete)
            {
                toDelete.Quantity -= quantityToDelete;
                Console.WriteLine($"Ilość {quantityToDelete} produktu {productName} została usuniętą z zamówienia");
                if (toDelete.Quantity == 0)
                {
                    _list.Remove(toDelete);
                    Console.WriteLine($"Produkt {productName} został całkowicie usunięty z listy");
                }
                
            }
            else
            {
                Console.WriteLine($"Produkt {productName} nie znajduje się w zamówieniu.");
            }
        }
        public decimal GetTotalValue()
        {
            decimal total = 0;
            foreach (var item in _list)
            {
                total += item.GetTotalPrice();
            }
            return total;
        }
        public void DisplayOrder()
        {
            Console.WriteLine("Twoje zamówienie :");
            foreach(var item in _list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Łączna wartość Twoje zamówienia wynosi {GetTotalValue()} PLN");
        }

    }
}
