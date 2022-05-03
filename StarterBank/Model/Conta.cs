using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string Numero { get; set; }
        public int Agencia { get; set; }
        public float Saldo { get; set; }
        public Cartao Cartao { get; set; }
    }
}