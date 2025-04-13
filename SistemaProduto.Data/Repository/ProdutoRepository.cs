using SistemaProduto.Data.Context;
using SistemaProduto.Data.Repository.Interface;
using SistemaProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbContexto _db;

        public ProdutoRepository(DbContexto db)
        {
            _db = db;
        }

        public void Adicionar(Produto produto)
        {
            _db.Add(produto);
            _db.SaveChanges();
        }

        public List<Produto> ListarProdutos(int paginaAtual, int itemPorPagina, out int totalItens)
        {
            totalItens = _db.Produtos.Count();

            return _db.Produtos
                .OrderBy(p => p.Id)
                .Skip((paginaAtual - 1) * itemPorPagina)
                .Take(itemPorPagina)
                .ToList();
        }
    }
}
