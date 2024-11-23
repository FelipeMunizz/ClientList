using Helpers.Utility;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Context;

public class AppDbContext : IDisposable
{
    private readonly string ConnectionString;
    private IDbConnection? _connection;

    public AppDbContext(IDbConnection connection)
    {
        ConnectionString = Util.ConectionString;
        _connection = connection;
    }

    /// <summary>
    /// Retorna a conexão aberta
    /// </summary>
    public IDbConnection Connection
    {
        get
        {
            if( _connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }

            return _connection; 
        }
    }

    public SqlTransaction? Transaction { get; set; }

    /// <summary>
    /// Fecha e limpa os recursos da conexão
    /// </summary>
    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
            _connection.Dispose();
        }

        _connection = null;
    }
}
