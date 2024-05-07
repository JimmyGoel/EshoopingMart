using Basket.API.Models;

namespace Basket.API.Basket.GetBasket
{
    public record GetbasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler
    {
    }
}
