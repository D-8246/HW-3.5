using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW_3._5.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class NorthwindManager
    {
        private string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProdcutsByMinAndMax(int min, int max)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products WHERE UnitsInStock BETWEEN @min AND @max";
            command.Parameters.AddWithValue("@min", min);
            command.Parameters.AddWithValue("@max", max);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();
            while(reader.Read())
            {
                products.Add(new Product
                {
                    Name = (string)reader["ProductName"],
                    Price = (decimal)reader["UnitPrice"],
                    UnitsInStock = (short)reader["UnitsInStock"]
                });
            }
            return products;
        }
    }
}