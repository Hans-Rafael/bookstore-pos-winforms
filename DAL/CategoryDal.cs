using System;
using System.Collections.Generic;
using System.Text;

using Entities;
using Microsoft.Data.SqlClient;

namespace Dal
{
    public class CategoryDal
    {
        private readonly DbConnection _db = new DbConnection();

        public List<Category> GetAll()
        {
            var list = new List<Category>();

            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT CategoryId, Name, IsActive FROM Categories WHERE IsActive = 1 ORDER BY Name;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            Name = reader["Name"].ToString() ?? string.Empty,
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }

            return list;
        }
        public void Insert(Category category)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Categories (Name) VALUES (@Name);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
