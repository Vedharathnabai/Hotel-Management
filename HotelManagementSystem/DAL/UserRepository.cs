using Dapper;
using HotelManagementSystem.Models;
using System.Data;
using System.Linq;

namespace HotelManagementSystem.Data
{
    public class UserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int CreateCustomer(Customer customer)
        {
            var query = @"INSERT INTO Customer (Name, Email, PhoneNumber, Address, Password) 
                          VALUES (@Name, @Email, @PhoneNumber, @Address, @Password);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            return _dbConnection.Query<int>(query, customer).Single();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var query = "SELECT * FROM Customer WHERE Email = @Email";
            return _dbConnection.Query<Customer>(query, new { Email = email }).SingleOrDefault();
        }
    }
}
