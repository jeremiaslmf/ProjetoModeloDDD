using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public Guid ClienteId { get; set; }
        public  virtual Cliente Cliente { get; set; }
    }
}
