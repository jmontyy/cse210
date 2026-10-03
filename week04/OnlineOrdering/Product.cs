public class Product(string name, int id, float price, int quantity)
{
    private string _name = name;
    private int _id = id;
    private float _price = price;
    private int _quantity = quantity;
    public string GetName() => _name;
    public int GetId() =>_id;
    public float GetCost() => _price * _quantity;
}
