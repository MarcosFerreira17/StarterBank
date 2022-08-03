using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ContaRegistroDTO
    {
        [Required]
        public int BancoId { get; set; }
        [Required]
        public float SaldoInicial { get; set; }
        [Required]
        public int ClienteId { get; set; }

    }
}