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
    }
}
