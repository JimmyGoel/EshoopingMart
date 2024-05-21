using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObject
{
    public record OrderID
    {
        public Guid Value { get; }
        private OrderID(Guid value)=> this.Value = value;
        public static OrderID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if(value == Guid.Empty)
            {
                throw new DomainException("OrderID cannot be empty.");
            }
            return new OrderID(value);
        }
    }
}
