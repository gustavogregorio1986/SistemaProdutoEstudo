using System.ComponentModel.DataAnnotations;

namespace SistemaProduto.Models
{
    public class ProdutoView
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome do Produto")]
        public string? NomeProduto { get; set; }

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public double TotalProdutos { get; set; }

        public string? Status { get; set; }
    }
}
