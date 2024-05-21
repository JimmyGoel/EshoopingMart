using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObject
{
    public record OrderName
    {
        public string Value { get; }
        private OrderName(string value) => this.Value = value;
        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value == string.Empty)
            {
                throw new DomainException("OrderName cannot be empty.");
            }
            return new OrderName(value);
        }
    }
}
