namespace Basket.Api.Entities;

public class ShoppingCart
{
    public ShoppingCart(string userName)
    {
        Items = new List<ShoppingCartItem>();
        UserName = userName;
    }
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }
    public double? TotalPrice
    {
        get
        {
            double? totalPrice = 0;
            Items.ForEach(item =>  totalPrice += item.Price * item.Quantity);
            return totalPrice;
        }
    }
}
