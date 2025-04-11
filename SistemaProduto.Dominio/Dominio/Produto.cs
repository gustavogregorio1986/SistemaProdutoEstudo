using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Dominio.Dominio
{
    public class Produto
    {
        public Guid Id { get; set; }

        public string? NomeProduto { get; set; }

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public double TotalProdutos { get; set; }

        public string? Status { get; set; }
    }
}
