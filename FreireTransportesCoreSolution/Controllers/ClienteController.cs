using FreireTransportesCoreSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreireTransportesCoreSolution.Controllers
{
    [Route("Cliente")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet("NovoCliente")]
        public IActionResult Cliente()
        {
            return View(_clienteService.PrepararClienteComTipos());
        }

        [HttpPost("NovoCliente")]
        public IActionResult Cliente(Cliente model)
        {
            if (ModelState.IsValid)
            { // Lógica de gravação no banco de dados
                _clienteService.AddCliente(model);
                return RedirectToAction("ListarClientes"); 
            } 
            else 
            { 
                return View(_clienteService.PrepararClienteComTipos()); 
            }
        }

        [HttpGet("ListarClientes")]
        public IActionResult ListarClientes()
        {
            var clientes = _clienteService.ListarClientes(); 
            return View(clientes);
        }

        [HttpGet("Alterar/{id}")]
        public IActionResult Alterar(int id) 
        {
            var cliente = _clienteService.ObterClientePorId(id);
            if (cliente == null) 
            {
                return NotFound(); 
            }
            cliente.optionsCliente = _clienteService.ListarTiposCliente().ToList();
            return View(cliente); 
        }

        [HttpPost("Alterar/{id}")]
        public IActionResult Alterar(Cliente model)
        {
            if (ModelState.IsValid) 
            { 
                _clienteService.AtualizarCliente(model); 
                return RedirectToAction("ListarClientes"); 
            }
            else
            { 
                // Recarregar as opções em caso de falha de validação
                model.optionsCliente = _clienteService.ListarTiposCliente().ToList(); 
                
                return View(model); 
            } 
        }
    }
}
