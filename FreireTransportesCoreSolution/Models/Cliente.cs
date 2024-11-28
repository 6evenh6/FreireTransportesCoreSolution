using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FreireTransportesCoreSolution.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O Nome do Cliente é obrigatório.")]
        public string rNome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string rCpfCnpj { get; set; }

        [Display(Name = "Tipo de Cliente")]
        [Required(ErrorMessage = " O Tipo de Cliente é obrigatório.")]
        public string rTipoCliente { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        public string rEmail { get; set; }

        [Display(Name = "Telefone")]
        public string rTelefone { get; set; }

        [Display(Name = "Rua")]
        public string rRua { get; set; }

        [Display(Name = "Número")]
        public int cNumero { get; set; }

        [Display(Name = "Complemento")]
        public string rComplemento { get; set; }

        [Display(Name = "Observações")]
        [Required(ErrorMessage = " O campo observações é obrigatório.")]
        public string rObservacoes { get; set; }

        //Data de Registro do Cliente
        public DateTime dDataRegistro { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = " O Celular é obrigatório.")]
        public string rCelular { get; set; }

        public IEnumerable<Cliente> clientes { get; set; }
    }
}
