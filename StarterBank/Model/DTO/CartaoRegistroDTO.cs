using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CartaoRegistroDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
        public string Senha { get; set; }

    }
}