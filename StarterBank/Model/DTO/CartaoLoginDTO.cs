using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CartaoLoginDTO
    {
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Senha { get; set; }

    }
}