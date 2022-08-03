using System;
using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model.DTO
{
    public class CaixaEletronicoDTO
    {
        [Required]
        public int nota100 { get; set; }
        [Required]
        public int nota50 { get; set; }
        [Required]
        public int nota20 { get; set; }
        [Required]
        public int nota10 { get; set; }
        [Required]
        public int BancoId { get; set; }

    }
}