namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> item { get; set; } = new();
        public decimal TotalPrice => item.Sum(x => x.Quantity * x.Price);
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart()
        {
                
        }
    }
}
