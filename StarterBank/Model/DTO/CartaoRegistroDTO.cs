using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CartaoRegistroDTO
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}