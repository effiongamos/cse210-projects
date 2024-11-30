using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product("Laptop", "P123", 500.00m, 2);
        Product product2 = new Product("Mouse", "P456", 20.00m, 3);
        Product product3 = new Product("Keyboard", "P789", 30.00m, 1);

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}

class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName() => _name;
    public string GetProductId() => _productId;
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA() => _country.ToLower() == "usa";

    public override string ToString()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;
    public Address GetAddress() => _address;
    public bool LivesInUSA() => _address.IsInUSA();
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.LivesInUSA() ? 5.00m : 35.00m;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}
