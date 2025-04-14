using Microsoft.AspNetCore.Mvc;
using SistemaProduto.Dominio.Dominio;
using SistemaProduto.Models;
using SistemaProduto.Service.Service.Interface;
using System.Globalization;

namespace SistemaProduto.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ProdutoView produtoView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoView.TotalProdutos = (double)(produtoView.Preco * produtoView.Quantidade) / 100;
                    Produto produto = new Produto
                    {
                        NomeProduto = produtoView.NomeProduto,
                        Preco = produtoView.Preco / 100,
                        Quantidade = produtoView.Quantidade,
                        TotalProdutos = produtoView.TotalProdutos,
                        Status = produtoView.Status
                    };

                    _produtoService.Adicionar(produto);
                    TempData["Mensagem"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Cadastrar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            // Aqui você retorna exatamente o mesmo objeto ProdutoView com os erros
            return View(produtoView);
        }

        [HttpPost]
        public IActionResult AlternarStatus(Guid id)
        {
            _produtoService.AlterarStatus(id);
            return RedirectToAction("Consultar");
        }

        public IActionResult Consultar(int paginaAtual = 1, int itensPorPagina = 5)
        {
            var produtos = _produtoService.ListarProdutos(paginaAtual, itensPorPagina, out int total);

            var viewModel = new IndexView
            { 
                Produtos = produtos,
                TotalItens = total,
                PaginaAtual = paginaAtual,
                ItensPorPagina = itensPorPagina
            };


            return View(viewModel);
        }

        public IActionResult ListarAtivos(int paginaAtual = 1, int ativo = 1, int itensPorPagina  = 5)
        {
            var produtos = _produtoService.ListarAtivos(paginaAtual, itensPorPagina, ativo, out int total);

            var viewModel = new IndexView
            { 
                 Produtos = produtos,
                 TotalItens = total,
                 PaginaAtual = paginaAtual,
                 ItensPorPagina = itensPorPagina
            };


            return View(viewModel);
        }

        public IActionResult ListarInativos(int paginaAtual = 1, int inativo = 0, int itensPorPagina = 5)
        {
            var produtos = _produtoService.ListarInativos(paginaAtual, itensPorPagina, inativo, out int total);

            var viewModel = new IndexView
            {
                Produtos = produtos,
                TotalItens = total,
                PaginaAtual = paginaAtual,
                ItensPorPagina = itensPorPagina
            };


            return View(viewModel);
        }
    }
}
