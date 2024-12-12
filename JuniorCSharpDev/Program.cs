using JuniorCSharpDev;

class Program
{
    public static void Main(string[] args)
    {
        var products = new Dictionary<int, Product>();

        products.Add(1, new Product("Laptop", 2500));
        products.Add(2, new Product("Klawiatura", 120));
        products.Add(3, new Product("Mysz", 90));
        products.Add(4, new Product("Monitor", 100));
        products.Add(5, new Product("Kaczka debuggująca", 66));

        bool programRunning = true;
        var order = new Order();

        Console.WriteLine("Przypominamy o promocji! Na drugi tańszy produkt 10% zniżki");
        Console.WriteLine("Lub dodaj trzy produkty i zyskaj 20% zniżki na najtanśzym produkcie");
        Console.WriteLine("Zrób zamówienie na kwotę wyższą niż 5000 PLN i otrzymaj 5% zniżki od całego zamówienia");
        while (programRunning)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Wyświetl wszystkie produkty");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl wartość zamówienia");
            Console.WriteLine("4. Wyjście");
            Console.WriteLine("Wybierz jedną z powyższych opcji");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nDostępne produkty:");
                        foreach (var item in products)
                        {
                            Console.WriteLine($"{item.Key}. {item.Value}");
                        }

                        Console.Write("Wybierz numer produktu: ");
                        if (int.TryParse(Console.ReadLine(), out int productChoice) && products.ContainsKey(productChoice))
                        {
                            Console.Write("Podaj ilość: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                            {
                                order.AddProduct(products[productChoice], quantity);
                                Console.WriteLine("Produkt dodany do zamówienia.");
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowa ilość.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer produktu.");
                        }
                        break;

                    case 2:
                        Console.Write("Podaj nazwę produktu do usunięcia: ");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Podaj ile sztuk chcesz usunąć");
                        if(int.TryParse(Console.ReadLine(),out int quantityToDelete) && quantityToDelete > 0)
                        {
                            order.DeleteProduct(productName,quantityToDelete);  
                        }
                        break;

                    case 3:
                        order.DisplayOrder();
                        break;

                    case 4:
                        programRunning = false;
                        Console.WriteLine("Do widzenia!");
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nieprawidłowe dane wejściowe.");
            }
        }
    }
}
