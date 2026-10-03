public class Address(string street, string city, string state, string country)
{
    private string _street = street;
    private string _city = city;
    private string _state = state;
    private string _country = country;
    public bool IsInUSA() => _country.Equals("usa", StringComparison.CurrentCultureIgnoreCase);
    public string GetAddressString() => $"{_street}\n{_city}, {_state}\n{_country}";
}
