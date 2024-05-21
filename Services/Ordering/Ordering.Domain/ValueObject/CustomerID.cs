using Ordering.Domain.Exceptions;
using Ordering.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObject
{
    public record CustomerID
    {
        public Guid Value { get; }
        public CustomerID(Guid value) => Value = value;
        public static CustomerID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CustomerId cannot be empty.");
            }
            return new CustomerID(value);
        }
    }
}
