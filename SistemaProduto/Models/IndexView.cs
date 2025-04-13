using SistemaProduto.Dominio.Dominio;

namespace SistemaProduto.Models
{
    public class IndexView
    {
        public List<Produto> Produtos { get; set; } = new();
        public int TotalItens { get; set; }
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }

        public int TotalPaginas => (int)Math.Ceiling((double)TotalItens / ItensPorPagina);
    }
}
