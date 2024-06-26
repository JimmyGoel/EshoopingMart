﻿using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public static Product create(ProductId id, string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var Product = new Product
            {
                Id = id,
                Name = name,
                Price = price,
            };
            return Product;
        }

    }
}
