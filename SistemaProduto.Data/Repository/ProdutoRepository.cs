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

        public void Atualizar(Produto produto)
        {
            _db.Produtos.Update(produto);
            _db.SaveChanges();
        }

        public List<Produto> ListarAtivos(int paginaAtual, int itemPorPagina, int ativo, out int totalItens)
        {
            var query = _db.Produtos.Where(p => p.Status == 1);

            totalItens = query.Count();

            return query
                .OrderBy(p => p.NomeProduto).
                Skip((paginaAtual - 1) * itemPorPagina).
                Take(itemPorPagina)
                .ToList();
        }

        public List<Produto> ListarInativos(int paginaAtual, int itemPorPagina, int inativo, out int totalItens)
        {
            var query = _db.Produtos.Where(p => p.Status == 0);

            totalItens = query.Count();

            return query
                .OrderBy(p => p.NomeProduto).
                Skip((paginaAtual - 1) * itemPorPagina).
                Take(itemPorPagina)
                .ToList();
        }

        public List<Produto> ListarProdutos(int paginaAtual, int itemPorPagina, out int totalItens)
        {
            totalItens = _db.Produtos.Count();

            return _db.Produtos
                .OrderBy(p => p.NomeProduto)
                .Skip((paginaAtual - 1) * itemPorPagina)
                .Take(itemPorPagina)
                .ToList();
        }

        public Produto ObterPorId(Guid id)
        {
            return _db.Produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}
