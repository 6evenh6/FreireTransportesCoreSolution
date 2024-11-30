using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreireTransportesCoreSolution.Models
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AddCliente(Cliente cliente)
        { // Validação ou outras regras de negócio
            _clienteRepository.InsertCliente(cliente);
        }
        public IEnumerable<Cliente> ListarClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public Cliente ObterClientePorId(int idCliente) 
        { 
            return _clienteRepository.GetClienteById(idCliente); 
        }

        public IEnumerable<SelectListItem> ListarTiposCliente()
        {
            return _clienteRepository.ObterTiposCliente(); 
        }
        public Cliente PrepararClienteComTipos() 
        { 
            var cliente = new Cliente 
            { 
                optionsCliente = _clienteRepository.ObterTiposCliente().ToList() 
            };
            
            return cliente; 
        }

        public void AtualizarCliente(Cliente cliente) 
        { 
            _clienteRepository.AtualizarCliente(cliente); 
        }
    }
}
