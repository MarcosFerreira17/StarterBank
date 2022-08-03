using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public float Saldo { get; set; }
        public int BancoId { get; set; }
        public int CartaoId { get; set; }
        public int ClienteId { get; set; }

    }
}