using Dapper;
using HotelManagementSystem.Models;
using System.Data;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    public class UserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(Customer customer)
        {
            var query = "INSERT INTO Customer (UserName, Email, PhoneNumber, Password, Location) " +
                        "VALUES (@UserName, @Email, @PhoneNumber, @Password, @Location);" +
                        "SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, customer);
            }
        }
    }
}
