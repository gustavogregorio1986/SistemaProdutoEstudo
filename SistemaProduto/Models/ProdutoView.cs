using System.ComponentModel.DataAnnotations;

namespace SistemaProduto.Models
{
    public class ProdutoView
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string? NomeProduto { get; set; }

        [Required(ErrorMessage = "Informe o preço.")]
        [Range(0.01, 9999999, ErrorMessage = "Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o total do produto")]
        public double TotalProdutos { get; set; }

        [Required(ErrorMessage = "Informe o status do produto")]
        public int Status { get; set; }
    }
}
