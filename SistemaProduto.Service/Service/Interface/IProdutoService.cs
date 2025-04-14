using SistemaProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Service.Service.Interface
{
    public interface IProdutoService
    {
        void Adicionar(Produto produto);

        List<Produto> ListarProdutos(int paginaAtual, int itensPorPagina, out int totalItens);

        List<Produto> ListarAtivos(int paginaAtual, int itemPorPagina, int ativo, out int totalItens);

        List<Produto> ListarInativos(int paginaAtual, int itemPorPagina, int inativo, out int totalItens);

        void AlterarStatus(Guid id);

    }
}
