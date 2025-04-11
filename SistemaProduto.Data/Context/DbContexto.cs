using Microsoft.EntityFrameworkCore;
using SistemaProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Data.Context
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
