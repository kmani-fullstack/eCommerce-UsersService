using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext(IConfiguration config)
{ 
    private readonly IDbConnection? _connection = new NpgsqlConnection(config.GetConnectionString("PostgresConnection"));
    
    public IDbConnection DbConnection => _connection ?? throw new NullReferenceException();
}