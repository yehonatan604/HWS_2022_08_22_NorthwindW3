using System;
using System.Collections.Generic;

namespace HWS_2022_08_22_NorthwindW3.Entities.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
