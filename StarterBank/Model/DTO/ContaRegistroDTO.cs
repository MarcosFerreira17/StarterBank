using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ContaRegistroDTO
    {
        [Required]
        public string NomeBanco { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public int Agencia { get; set; }
        [Required]
        public float Saldo { get; set; }
        [Required]
        public int CartaoId { get; set; }
        public int CaixaId { get; set; }
    }
}