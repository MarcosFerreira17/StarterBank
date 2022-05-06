using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model.DTO
{
    public class BancoDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Faixa { get; set; }
        [Required]
        public int NumeroAgencia { get; set; }
    }
}