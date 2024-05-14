
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.GetBasket
{
    //public record GetbasketRequest(string UserName);
    public record GetbasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{Name}", async (string Name, ISender sender) =>
            {
                var result = await sender.Send(new GetbasketQuery(Name));
                var response = result.Adapt<GetbasketResponse>();
                return Results.Ok(response);
            })
         .WithName("GetProductsById")
        .Produces<GetbasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products by Id")
        .WithDescription("Get Products by Id"); 
        }
    }
}
