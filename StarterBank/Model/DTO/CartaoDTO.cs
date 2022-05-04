using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CartaoDTO
    {
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Senha { get; set; }

    }
}