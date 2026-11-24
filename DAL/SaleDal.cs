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
        public List<Sale> GetSalesByDate(DateTime from, DateTime to)
        {
            var list = new List<Sale>();

            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT SaleId, SaleDate, TotalAmount, PaymentMethod
            FROM Sales
            WHERE CAST(SaleDate AS DATE) BETWEEN @From AND @To
            ORDER BY SaleDate DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.Date);
                    cmd.Parameters.AddWithValue("@To", to.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Sale
                            {
                                SaleId = Convert.ToInt32(reader["SaleId"]),
                                SaleDate = Convert.ToDateTime(reader["SaleDate"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                PaymentMethod = reader["PaymentMethod"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }

            return list;
        }

        public List<SaleDetail> GetSaleDetails(int saleId)
        {
            var list = new List<SaleDetail>();

            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT sd.SaleDetailId, sd.SaleId, sd.BookId, b.Title AS BookTitle, sd.Quantity, sd.UnitPrice
            FROM SaleDetails sd
            INNER JOIN Books b ON sd.BookId = b.BookId
            WHERE sd.SaleId = @SaleId;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleId", saleId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SaleDetail
                            {
                                SaleDetailId = Convert.ToInt32(reader["SaleDetailId"]),
                                SaleId = Convert.ToInt32(reader["SaleId"]),
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BookTitle = reader["BookTitle"].ToString() ?? string.Empty,
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
