using Dapper;
using FreireTransportesCoreSolution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FreireTransportesCoreSolution.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IDbConnection _dbConnection;
        public ClienteController(IConfiguration configuration) 
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")); 
        }


        [HttpGet]
        public IActionResult Index(Cliente _Model)
        {
            
            return View();
        }


        [HttpGet]
        public IActionResult Details(Cliente _Model)
        {
            _Model = new Cliente();
            _Model.clientes = _dbConnection.Query<Cliente>("SELECT * FROM tCliente");

            return View(_Model);
            
        }

        [HttpGet("Alterar/{id}")]
        public IActionResult Alterar(int? id, Cliente _Model)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Simulação de busca de cliente por ID (substitua com sua lógica)
            // Obtenha o cliente pelo ID (substitua com sua lógica de obtenção de dados)

            var sql = "SELECT * FROM tCliente WHERE idCliente = @Id"; 

            var cliente = _dbConnection.QuerySingleOrDefault<Cliente>(sql, new { Id = id }); 

            if (cliente == null) 
            {
                return NotFound(); 
            } 
            
            return View(cliente);

        }
        [HttpPost]
        public IActionResult SalvarAlteracao(Cliente _Model)
        {
            _Model = new Cliente();

            return View();
        }


    }
}
