using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.Data.SqlClient;

namespace Dal
{
    public class BookDal
    {
        private readonly DbConnection _db = new DbConnection();

        public List<Book> GetAll(string search = "")
        {
            var list = new List<Book>();

            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.BookId, b.ISBN, b.Title, b.Author, b.CategoryId,
                           c.Name AS CategoryName, b.Price, b.Stock, b.MinStock, b.IsActive, b.CreatedAt
                    FROM Books b
                    INNER JOIN Categories c ON b.CategoryId = c.CategoryId
                    WHERE b.IsActive = 1
                      AND (b.Title LIKE @Search OR b.Author LIKE @Search OR b.ISBN LIKE @Search)
                    ORDER BY b.Title;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Book
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                ISBN = reader["ISBN"].ToString() ?? string.Empty,
                                Title = reader["Title"].ToString() ?? string.Empty,
                                Author = reader["Author"].ToString() ?? string.Empty,
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader["CategoryName"].ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                MinStock = Convert.ToInt32(reader["MinStock"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        public void Insert(Book book)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Books (ISBN, Title, Author, CategoryId, Price, Stock, MinStock)
                    VALUES (@ISBN, @Title, @Author, @CategoryId, @Price, @Stock, @MinStock);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    cmd.Parameters.AddWithValue("@Stock", book.Stock);
                    cmd.Parameters.AddWithValue("@MinStock", book.MinStock);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Book book)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Books
                    SET ISBN = @ISBN, Title = @Title, Author = @Author,
                        CategoryId = @CategoryId, Price = @Price, Stock = @Stock, MinStock = @MinStock
                    WHERE BookId = @BookId;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookId", book.BookId);
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    cmd.Parameters.AddWithValue("@Stock", book.Stock);
                    cmd.Parameters.AddWithValue("@MinStock", book.MinStock);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deactivate(int bookId)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Books SET IsActive = 0 WHERE BookId = @BookId;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}