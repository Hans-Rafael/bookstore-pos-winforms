using System;
using System.Collections.Generic;
using System.Text;

using Dal;
using Entities;

namespace BLL
{
    public class SaleBLL
    {
        private readonly SaleDal _saleDal = new SaleDal();

        public int RegisterSale(Sale sale)
        {
            if (sale.Details == null || sale.Details.Count == 0)
                throw new ArgumentException("Add at least one book to the cart.");

            if (string.IsNullOrWhiteSpace(sale.PaymentMethod))
                throw new ArgumentException("Select a payment method.");

            sale.TotalAmount = sale.Details.Sum(d => d.Subtotal);

            return _saleDal.RegisterSale(sale);
        }
        public List<Sale> GetSalesByDate(DateTime from, DateTime to)
        {
            if (from.Date > to.Date)
                throw new ArgumentException("Start date cannot be greater than end date.");

            return _saleDal.GetSalesByDate(from, to);
        }

        public List<SaleDetail> GetSaleDetails(int saleId) => _saleDal.GetSaleDetails(saleId);
    }
}