

using Basket.API.Data;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.cart).NotNull().WithMessage("Cart Cannot be null");
            RuleFor(x => x.cart.UserName).NotNull().WithMessage("User Name cannot be null");
        }
    }
    public class StoreBasketCommandHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.cart;
            var result = await basketRepository.StoreBasket(cart,cancellationToken);
            return new StoreBasketResult(result.UserName);
        }
    }
}
