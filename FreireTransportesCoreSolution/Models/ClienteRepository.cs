using Dapper;
using System.Data;

namespace FreireTransportesCoreSolution.Models
{
    public class ClienteRepository
    {
        private readonly IDbConnection _dbConnection; 
        public ClienteRepository(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection; 
        } 
        public IEnumerable<Cliente> GetAllClientes() 

        {
            string sql = "SELECT * FROM Clientes"; 
            return _dbConnection.Query<Cliente>(sql); 
        }
        
        public Cliente GetClienteById(int id) 
        { 
            string sql = "SELECT * FROM Clientes WHERE idCliente = @Id"; 
            return _dbConnection.QuerySingleOrDefault<Cliente>(sql, new { Id = id }); 
        }
    }
}
