namespace Basket.API.Basket.GetBasket
{
    public record GetbasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler : IQueryHandler<GetbasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetbasketQuery query, CancellationToken cancellationToken)
        {
            return new GetBasketResult(new ShoppingCart("SWN"));
            //throw new NotImplementedException();
        }
    }
}
