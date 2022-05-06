using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ExtratoDTO
    {
        [Required]
        public int BancoId { get; set; }
        [Required]
        public int ContaId { get; set; }
        [Required]
        public int ValorDoSaque { get; set; }

    }
}