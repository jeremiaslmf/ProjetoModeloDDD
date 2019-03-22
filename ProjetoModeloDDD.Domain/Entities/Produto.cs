using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        public  virtual Cliente Cliente { get; set; }
    }
}
