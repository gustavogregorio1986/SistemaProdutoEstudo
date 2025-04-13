using Microsoft.AspNetCore.Mvc;
using SistemaProduto.Dominio.Dominio;
using SistemaProduto.Models;
using SistemaProduto.Service.Service.Interface;

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
                    Produto produto = new Produto
                    {
                        NomeProduto = produtoView.NomeProduto,
                        Preco = produtoView.Preco,
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



        public IActionResult Consultar()
        {
            return View();
        }

        public IActionResult ListarAtivos()
        {
            return View();
        }

        public IActionResult ListarInativos()
        {
            return View();
        }
    }
}
