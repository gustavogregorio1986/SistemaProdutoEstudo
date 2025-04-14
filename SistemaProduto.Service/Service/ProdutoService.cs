using SistemaProduto.Data.Repository.Interface;
using SistemaProduto.Dominio.Dominio;
using SistemaProduto.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
             _produtoRepository = produtoRepository;
        }

        public void Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        public void AlterarStatus(Guid id)
        {
            var produto = _produtoRepository.ObterPorId(id);

            if (produto == null)
                throw new Exception("Produto não encontrado!");

            produto.AlterarSytatus();

            _produtoRepository.Atualizar(produto);
        }

        public List<Produto> ListarAtivos(int paginaAtual, int itemPorPagina, int ativo, out int totalItens)
        {
            return _produtoRepository.ListarAtivos(paginaAtual, itemPorPagina, ativo, out totalItens);
        }

        public List<Produto> ListarInativos(int paginaAtual, int itemPorPagina, int inativo, out int totalItens)
        {
            return _produtoRepository.ListarInativos(paginaAtual, itemPorPagina, inativo, out totalItens);
        }

        public List<Produto> ListarProdutos(int paginaAtual, int itensPorPagina, out int totalItens)
        {
            return _produtoRepository.ListarProdutos(paginaAtual, itensPorPagina, out totalItens);
        }
    }
}
