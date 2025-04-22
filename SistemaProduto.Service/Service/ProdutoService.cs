using ClosedXML.Excel;
using SistemaProduto.Data.DTO;
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

        public void AlterarStatus(Guid id)
        {
            var produto = _produtoRepository.ObterPorId(id);

            if (produto == null)
                throw new Exception("Produto não encontrado!");

            produto.AlterarSytatus();

            _produtoRepository.Atualizar(produto);
        }

        public ExportacaoExcelResultado ExportarProdutosParaExcel(int paginaAtual, int itensPorPagina)
        {
            int totalItens;
            var produtos = _produtoRepository.ListarProdutos(paginaAtual, itensPorPagina, out totalItens);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Produtos");

                decimal totalGeral = 0;

                // Cabeçalhos
                worksheet.Cell(1, 1).Value = "Nome do Produto";
                worksheet.Cell(1, 2).Value = "Preço";
                worksheet.Cell(1, 3).Value = "Quantidade";
                worksheet.Cell(1, 4).Value = "Total Produto";
                worksheet.Cell(1, 5).Value = "Status";

                int linha = 2;
                foreach (var produto in produtos)
                {
                    var totalProduto = produto.Preco * produto.Quantidade;

                    worksheet.Cell(linha, 1).Value = produto.NomeProduto;
                    worksheet.Cell(linha, 2).Value = produto.Preco;
                    worksheet.Cell(linha, 3).Value = produto.Quantidade;
                    worksheet.Cell(linha, 4).Value = totalProduto;
                    worksheet.Cell(linha, 5).Value = produto.Status == 1 ? "Ativo" : "Inativo";
                    totalGeral += totalProduto;
                    linha++;
                }

                // Total Geral na última linha
                worksheet.Cell(linha + 1, 3).Value = "TOTAL GERAL:";
                worksheet.Cell(linha + 1, 4).Value = totalGeral;
                worksheet.Cell(linha + 1, 4).Style.NumberFormat.Format = "#,##0.00";

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return new ExportacaoExcelResultado
                    {
                        Arquivo = stream.ToArray(),
                        TotalItens = totalItens
                    };
                }
            }
        }

        public List<Produto> ListarAtivos(int paginaAtual, int itemPorPagina, int ativo, out int totalItens)
        {
            return _produtoRepository.ListarAtivos(paginaAtual, itemPorPagina, ativo, out totalItens);
        }

        public List<Produto> ListarInativos(int paginaAtual, int itemPorPagina, int inativo, out int totalItens)
        {
            return _produtoRepository.ListarInativos(paginaAtual, itemPorPagina, inativo, out totalItens);
        }

        public List<Produto> ListarProdutos(int paginaAtual, int itensPorPagina, out int totalItens)
        {
            return _produtoRepository.ListarProdutos(paginaAtual, itensPorPagina, out totalItens);
        }
    }
}
