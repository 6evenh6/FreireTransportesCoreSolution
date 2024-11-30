using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "O Tipo de Cliente é obrigatório.")]
        public string cTipoCliente { get; set; }

        public List<SelectListItem>? optionsCliente { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail deve ser válido.")]
        public string rEmail { get; set; }

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\(\d{2}\) \d{4}\-\d{4}$", ErrorMessage = "Formato de telefone inválido.")]
        public string rTelefone { get; set; }

        [Display(Name = "Rua")]
        public string rRua { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Número deve ser um valor positivo.")]
        public int? cNumero { get; set; }

        [Display(Name = "Complemento")]
        public string rComplemento { get; set; }

        [Display(Name = "Observações")]
        [Required(ErrorMessage = "O campo observações é obrigatório.")]
        public string rObservacoes { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{5}\-\d{4}$", ErrorMessage = "Formato de celular inválido.")]
        public string rCelular { get; set; }

        public DateTime dDataRegistro { get; set; }

        public IEnumerable<Cliente>? clientes { get; set; }

    }
}
