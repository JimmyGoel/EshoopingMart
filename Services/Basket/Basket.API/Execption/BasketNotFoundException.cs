

namespace Basket.API.Execption
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string userName) : base("basket", userName)
        {

        }
    }
}
