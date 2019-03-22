using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        [Column(TypeName="datetime2")]
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool ValidarClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && (DateTime.Now.Year - cliente.DataCadastro?.Year) >= 5;
        }
    }
}
