using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string NumeroConta { get; set; }
        public int NumeroAgencia { get; set; }
        public float Saldo { get; set; }
        public Cartao Cartao { get; set; }
        public CaixaEletronico Caixa { get; set; }
    }
}