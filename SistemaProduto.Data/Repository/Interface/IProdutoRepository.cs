using SistemaProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Data.Repository.Interface
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);

        List<Produto> ListarProdutos(int paginaAtual, int itemPorPagina, out int totalItens);

        List<Produto> ListarAtivos(int paginaAtual, int itemPorPagina, int ativo, out int totalItens);

        List<Produto> ListarInativos(int paginaAtual, int itemPorPagina, int inativo, out int totalItens);

        Produto ObterPorId(Guid id);

        void Atualizar(Produto produto);

    }
}
