using System.Data;
using System.Data.SqlClient;
using MvcAdoCrud.Models;
using Microsoft.Extensions.Configuration;

namespace MvcAdoCrud.Data
{
    public class CustomerProductRepository
    {
        private readonly string _connectionstring;
            public CustomerProductRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public void AddCustomerProduct(CustomerProduct customerProduct)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CustomerProduct (CustomerId,Id,PurchaseDate) VALUES (@CustomerId, @Id, @PurchaseDate)", conn);
                cmd.Parameters.AddWithValue("@Id", customerProduct.Id);
                cmd.Parameters.AddWithValue("@CustomerId", customerProduct.CustomerId);
                cmd.Parameters.AddWithValue("@PurchaseDate", customerProduct.PurchaseDate);
                cmd.ExecuteNonQuery();
            }
        }
        public List<CustomerProduct> GetAllCustomerProduct()
        {
            var customerproduct = new List<CustomerProduct>();
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open ();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CustomerProduct",conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customerproduct.Add(new CustomerProduct
                    {
                        CustomerId = (int)reader["CustomerId"],
                        Id = (int)reader["Id"],
                        PurchaseDate = (DateTime)reader["PurchaseDate"]
                    });
                }

            }
            return customerproduct;
        }
        public CustomerProduct GetCustomerProductById(int Id, int CustomerId) 
        {
                CustomerProduct customerproduct = null;
                using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CustomerProduct WHERE Id = @Id AND CustomerId = @CustomerId", conn);
                cmd.Parameters.AddWithValue("@Id", customerproduct.Id);
                cmd.Parameters.AddWithValue("@CustomerId", customerproduct.CustomerId);
                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        customerproduct = new CustomerProduct
                        {
                            CustomerId = (int)reader["CustomerId"],
                            Id = (int)reader["Id"],
                            PurchaseDate = (DateTime)reader["PurchaseDate"]
                        };
                    }
            }
                return customerproduct;
        }
        public void UpdateCustomerProduct(CustomerProduct customerProduct)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE CustomerProduct SET PurchaseDate = @PurchaseDate WHERE CustomerId = @CustomerId AND Id = @Id", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerProduct.CustomerId);
                cmd.Parameters.AddWithValue("@Id", customerProduct.Id);
                cmd.Parameters.AddWithValue("@PurchaseDate", customerProduct.PurchaseDate);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCustomerProduct(int customerId, int Id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CustomerProduct WHERE CustomerId = @CustomerId AND Id = @Id", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Id", Id);
            }
        }


    }
}
