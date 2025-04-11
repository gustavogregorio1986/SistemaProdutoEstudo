using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProduto.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeProduto)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("DOUBLE(10,2)");

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("DOUBLE(10,2)");

            builder.Property(x => x.TotalProdutos)
               .IsRequired()
               .HasColumnType("DOUBLE(10,2)");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("INT");
        }
    }
}
