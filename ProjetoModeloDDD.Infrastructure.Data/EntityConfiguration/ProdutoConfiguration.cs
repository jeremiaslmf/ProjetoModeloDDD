﻿using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infrastructure.Data.EntityConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Valor)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
