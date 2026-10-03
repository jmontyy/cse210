public class Order(List<Product> products, Customer customer)
{
    private List<Product> _products = products;
    private Customer _customer = customer;

    public float GetTotalCost()
    {
        float total = 0;
        foreach (Product product in _products)
            total += product.GetCost();

        if (_customer.IsInUSA())
            total += 5;
        else
            total += 35;

        return total;
    }
    public string GetPackagingLabel()
    {
        string label = "PACKING LABEL\n";

        foreach (Product product in _products)
        {
            label += $"{product.GetName()} - Product ID: {product.GetId()}\n";
        }

        return label;
    }
    public string GetShippingLabel() => $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetAddress()}";
}
