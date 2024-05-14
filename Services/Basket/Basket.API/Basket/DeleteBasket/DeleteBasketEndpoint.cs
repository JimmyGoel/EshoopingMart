
using Basket.API.Basket.StoreBasket;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.DeleteBasket
{
    //public record DeletebasketRequest(string UserName);
    public record DeletebasketResult(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/DeleteBasket/{UserName}", async (string UserName, ISender sender) =>
            {
                var response = await sender.Send(new DeleteBasketCommand(UserName));
                var result = response.Adapt<DeletebasketResult>();
                return Results.Ok(result);
            })
        .WithName("DeleteBasket")
       .Produces<GetbasketResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Delete Product")
       .WithDescription("Delete Product");
        }
    }
}
