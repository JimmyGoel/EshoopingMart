using Basket.API.Data;

namespace Basket.API.Basket.GetBasket
{
    public record GetbasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository basketRepository) : IQueryHandler<GetbasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetbasketQuery query, CancellationToken cancellationToken)
        {
            // TODO: We are unable to use Docker in my system that why not able to install postgrace sql Db but rest of functionality I have done
            var basket = await basketRepository.GetBasket(query.UserName);

            return new GetBasketResult(basket);
         
        }
    }
}
