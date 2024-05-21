﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Enum
{
    public enum OrderStatus
    {
        Draft = 1,
        Pending = 2,
        Completed = 3,
        Canceled = 4,
    }
}
