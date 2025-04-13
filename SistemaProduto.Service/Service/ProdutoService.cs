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

        public List<Produto> ListarProdutos(int paginaAtual, int itensPorPagina, out int totalItens)
        {
            return _produtoRepository.ListarProdutos(paginaAtual, itensPorPagina, out totalItens);
        }
    }
}
