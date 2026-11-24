using System;
using System.Collections.Generic;
using System.Text;

using Entities;
using Microsoft.Data.SqlClient;

namespace Dal
{
    public class SaleDal
    {
        private readonly DbConnection _db = new DbConnection();

        public int RegisterSale(Sale sale)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertSale = @"
                        INSERT INTO Sales (TotalAmount, PaymentMethod)
                        VALUES (@TotalAmount, @PaymentMethod);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int saleId;
                    using (SqlCommand cmdSale = new SqlCommand(insertSale, conn, transaction))
                    {
                        cmdSale.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                        cmdSale.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod);
                        saleId = Convert.ToInt32(cmdSale.ExecuteScalar());
                    }

                    string insertDetail = @"
                        INSERT INTO SaleDetails (SaleId, BookId, Quantity, UnitPrice)
                        VALUES (@SaleId, @BookId, @Quantity, @UnitPrice);";

                    string updateStock = @"
                        UPDATE Books
                        SET Stock = Stock - @Quantity
                        WHERE BookId = @BookId AND Stock >= @Quantity;";

                    foreach (var item in sale.Details)
                    {
                        using (SqlCommand cmdDetail = new SqlCommand(insertDetail, conn, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@SaleId", saleId);
                            cmdDetail.Parameters.AddWithValue("@BookId", item.BookId);
                            cmdDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            cmdDetail.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdStock = new SqlCommand(updateStock, conn, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@BookId", item.BookId);
                            cmdStock.Parameters.AddWithValue("@Quantity", item.Quantity);
                            int rowsAffected = cmdStock.ExecuteNonQuery();

                            if (rowsAffected == 0)
                                throw new InvalidOperationException($"Insufficient stock for '{item.BookTitle}'.");
                        }
                    }

                    transaction.Commit();
                    return saleId;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
