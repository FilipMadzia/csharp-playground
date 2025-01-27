using System;
using System.Collections.Generic;

namespace database_first_approach.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
