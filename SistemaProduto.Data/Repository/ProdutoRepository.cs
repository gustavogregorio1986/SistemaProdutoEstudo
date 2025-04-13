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
    }
}
