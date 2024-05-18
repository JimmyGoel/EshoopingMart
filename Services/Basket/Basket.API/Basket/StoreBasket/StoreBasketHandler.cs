

using Basket.API.Data;
using Discount.Grpc;

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
    public class StoreBasketCommandHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discount) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //ShoppingCart cart = command.cart;
            await DeductCouponDiscount(command.cart, cancellationToken);
            var result = await basketRepository.StoreBasket(command.cart, cancellationToken);
            return new StoreBasketResult(result.UserName);
        }

        private async Task DeductCouponDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var coupon = await discount.GetDiscountAsync(new GetDiscountRequest() { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
