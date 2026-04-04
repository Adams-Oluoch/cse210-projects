using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetSubTotal()
    {
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }

    public decimal GetShippingCost()
    {
        if (_customer.LivesInUSA())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }

    public decimal GetTotalPrice()
    {
        return GetSubTotal() + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n----------------------------------------\n";
        foreach (Product product in _products)
        {
            label += $"  • {product.GetName()} ({product.GetProductId()})\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n----------------------------------------\n  {_customer.GetName()}\n  {_customer.GetAddressString().Replace("\n", "\n  ")}";
    }
}