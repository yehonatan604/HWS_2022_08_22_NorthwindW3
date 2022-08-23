using System;
using System.Collections.Generic;

namespace HWS_2022_08_22_NorthwindW3.Entities.Models
{
    public partial class OrderDetailsExtended
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public decimal? ExtendedPrice { get; set; }
    }
}
