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
            var itemCounter = 0;
            decimal total = 0;
            foreach (var item in _list)
            {
                total += item.GetTotalPrice();
                itemCounter++;
            }
            switch(itemCounter)
            {
                case < 2:
                    return total;
                case 2:
                    var firstProduct = _list[0];
                    var secondProduct = _list[1];
                    if (firstProduct.Product.Price > secondProduct.Product.Price)
                    {
                        total = firstProduct.GetTotalPrice() +(secondProduct.GetTotalPrice() * (decimal)0.9);
                        Console.WriteLine($"Udzielono rabat 10% na tańszy produkt, którym jest {secondProduct.Product.ProductName}.");
                      
                    } 
                    else
                    {
                        total = secondProduct.GetTotalPrice() + (firstProduct.GetTotalPrice() * (decimal)0.9);
                        Console.WriteLine($"Udzielono rabat 10% na tańszy produkt, którym jest {firstProduct.Product.ProductName}.");
                    }
                    break;
                case 3:
                    var cheapestItem = _list.OrderBy(product => product.Product.Price).First();
                    var discount = cheapestItem.Product.Price * (decimal)0.2;
                    total -= discount;
                    Console.WriteLine($"Udzielono 20% rabatu na trzeci najtańszy produkt {cheapestItem.Product.ProductName}");
                    break;
                
                    
                

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
