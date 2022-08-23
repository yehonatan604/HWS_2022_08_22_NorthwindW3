using System;
using System.Collections.Generic;

namespace HWS_2022_08_22_NorthwindW3.Entities.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
