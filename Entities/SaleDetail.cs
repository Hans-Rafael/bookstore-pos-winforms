using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}