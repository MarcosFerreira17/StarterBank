using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CartaoRegistroDTO
    {
        [Required]
        public string Senha { get; set; }

    }
}