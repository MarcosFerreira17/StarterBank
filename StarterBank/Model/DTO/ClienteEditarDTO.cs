using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ClienteEditarDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Profissao { get; set; }

    }
}