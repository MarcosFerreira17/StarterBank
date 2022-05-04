using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ContaDTO
    {
        [Required]
        public string NomeBanco { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public int Agencia { get; set; }
        [Required]
        public float Saldo { get; set; }
        public Cartao Cartao { get; set; }
        public int CartaoId { get; set; }

    }
}