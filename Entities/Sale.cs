using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public List<SaleDetail> Details { get; set; } = new List<SaleDetail>();
    }
}