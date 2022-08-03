using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ClienteDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Profissao { get; set; }
        [Required]
        public string CPF { get; set; }
        public int ContaId { get; set; }

    }
}