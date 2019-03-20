﻿using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infrastructure.Data.EntityConfiguration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infrastructure.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            #endregion

            #region Definições Tipagem
            /// Define automaticamente as propriedades que possuem "Id" no nome como PrimeryKey
            modelBuilder.Properties()
                .Where(x => x.Name == x.ReflectedType.Name + "Id")
                .Configure(x => x.IsKey());

            /// Define automaticamente as propriedades do tipo string como "varchar"
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            /// Define automaticamente as propriedades do tipo string com tamanho maximo de 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            #endregion

            #region Configurações
            ///Define ao contexto que as configurações serão pegas desta classe
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            #endregion
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }
            return base.SaveChanges();
        }
    }
}