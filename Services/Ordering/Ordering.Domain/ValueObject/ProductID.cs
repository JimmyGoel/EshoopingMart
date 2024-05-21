using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObject
{
    public record ProductId
    {
        public Guid Value { get; }
        private ProductId(Guid value) => this.Value = value;
        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("ProductId cannot be empty.");
            }
            return new ProductId(value);
        }
    }
}
