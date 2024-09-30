using System.Data;
using System.Data.SqlClient;
using MvcAdoCrud.Models;
using Microsoft.Extensions.Configuration;

namespace MvcAdoCrud.Data
{
    public class CustomerRepository
    {
        private readonly string _conenect;
        public CustomerRepository(IConfiguration configuration)
        {
            _conenect = configuration.GetConnectionString("DefaultConnection");
        }
        public void Addcustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_conenect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Customername) VALUES (@CustomerName)", conn);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Customer> GetAllCustomers() 
        {
            var customer =new List<Customer>();
            using (SqlConnection conn = new SqlConnection(_conenect))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        CustomerName = (string)reader["CustomerName"],
                    });
                }
            }
            return customer;
        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            using (SqlConnection conn = new SqlConnection(_conenect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerId = @CustomerId", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    customer = new Customer
                    {
                        CustomerId = (int)reader["Id"],
                        CustomerName = (string)reader["Name"],
                    };

            }
            return customer;

        }
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_conenect))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET CustomerName=@CustomerName WHERE CustomerID=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCustomer(int id)
        {
            using (SqlConnection conn = new SqlConnection(_conenect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE CustomerId = @CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", id);
                cmd.ExecuteNonQuery();
            }


        }

    }
}
