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

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public double TotalProdutos { get; set; }

        public int Status { get; set; }

        public Produto()
        {
            
        }

        public Produto(string nomeProduto)
        {
            Id = Guid.NewGuid();
            NomeProduto = nomeProduto;
            Status = 1;

        }

        public void AlterarSytatus()
        {
            Status = Status == 1 ? 0 : 1;
        }
    }
}
