using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

    }
}