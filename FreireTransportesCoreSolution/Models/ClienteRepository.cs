using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
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
        public IEnumerable<Cliente> GetClientes()
        {
            return _dbConnection.Query<Cliente>("pSelectClientes", commandType: CommandType.StoredProcedure);
        }

        public Cliente GetClienteById(int idCliente)
        {
            var parameters = new
            {
                IdCliente = idCliente
            };
            return _dbConnection.QuerySingleOrDefault<Cliente>("pSelectClienteById", parameters, commandType: CommandType.StoredProcedure);
        }
        public void InsertCliente(Cliente cliente)
        {
            //Parametros para registro de informações do cliente no banco
            var parameters = new
            {
                rNome = cliente.rNome,
                rCpfCnpj = cliente.rCpfCnpj,
                rEmail = cliente.rEmail,
                rRua = cliente.rRua,
                cNumero = cliente.cNumero,
                rComplemento = cliente.rComplemento,
                rObservacoes = cliente.rObservacoes,
                dDataRegistro = DateTime.Now,
                rCelular = cliente.rCelular,
                rTelefone = cliente.rTelefone,
                cTipoCliente = cliente.cTipoCliente
            };

            _dbConnection.Execute("pInsertCliente", parameters, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<SelectListItem> ObterTiposCliente()
        {
            return _dbConnection.Query<SelectListItem>("pObterTiposCliente", commandType: CommandType.StoredProcedure).ToList();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            {
                var parameters = new
                {
                    cliente.idCliente,
                    cliente.rNome,
                    cliente.rCpfCnpj,
                    cliente.rEmail,
                    cliente.rRua,
                    cliente.cNumero,
                    cliente.rComplemento,
                    cliente.rObservacoes,
                    cliente.dDataRegistro,
                    cliente.rCelular,
                    cliente.rTelefone,
                    cliente.cTipoCliente
                };

                _dbConnection.Execute("pAtualizarCliente", parameters, commandType: CommandType.StoredProcedure);

            }
        }
    }
    
}
