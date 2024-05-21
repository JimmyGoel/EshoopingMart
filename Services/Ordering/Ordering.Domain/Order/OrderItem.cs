using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Order
{
    public class OrderItem : Entity<OrderItemId>
    {
        public OrderID OrderID { get; private set; } = default!;
        public ProductId ProductID { get; private set; } = default!;

        public int Quantity { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;

        public OrderItem(OrderID orderID, ProductId productID, int quantity, decimal price)
        {
            Id = OrderItemId.Of(Guid.NewGuid());
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            Price = price;
        }
    }
}
