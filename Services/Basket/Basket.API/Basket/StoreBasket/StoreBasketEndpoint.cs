


namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StorebasketResult(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/StoreBasket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var response = await sender.Send(command);
                var result = response.Adapt<StoreBasketResult>();
                return Results.Created($"/StoreBasket/{result.UserName}", result);
            })
         .WithName("CreateProduct")
        .Produces<GetbasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
        }
    }
}
