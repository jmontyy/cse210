public class Customer(string name, Address address)
{
    private string _name = name;
    private Address _address = address;
    public bool IsInUSA() => _address.IsInUSA();
    public string GetName() => _name;
    public string GetAddress() => _address.GetAddressString();
}
