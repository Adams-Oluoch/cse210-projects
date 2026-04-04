using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address(
            "789 Oak Avenue",
            "Austin",
            "TX",
            "USA");

        Customer customer1 = new Customer("Sarah Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Gaming Chair", "GCH100", 150.00m, 1));
        order1.AddProduct(new Product("LED Light Strip", "LED200", 25.00m, 1));
        order1.AddProduct(new Product("Desk Mat", "DMK300", 12.50m, 1));

        
        Address address2 = new Address(
            "22 Maple Street",
            "Vancouver",
            "BC",
            "Canada");

        Customer customer2 = new Customer("David Kim", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Coffee Mug", "CMG400", 12.50m, 1));
        order2.AddProduct(new Product("Tea Set", "TST500", 40.00m, 1));

        Console.WriteLine("========================================");
        Console.WriteLine("              ORDER #1");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        string shippingType = order1.GetShippingCost() == 5 ? "USA" : "International";
        Console.WriteLine($"SHIPPING COST: ${order1.GetShippingCost():0.00} ({shippingType})");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"SUB TOTAL: ${order1.GetSubTotal():0.00}");
        Console.WriteLine($"SHIPPING:   ${order1.GetShippingCost():0.00}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"TOTAL:    ${order1.GetTotalPrice():0.00}");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("              ORDER #2");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        shippingType = order2.GetShippingCost() == 5 ? "USA" : "International";
        Console.WriteLine($"SHIPPING COST: ${order2.GetShippingCost():0.00} ({shippingType})");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"SUB TOTAL: ${order2.GetSubTotal():0.00}");
        Console.WriteLine($"SHIPPING:   ${order2.GetShippingCost():0.00}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"TOTAL:    ${order2.GetTotalPrice():0.00}");
        Console.WriteLine("========================================");

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}