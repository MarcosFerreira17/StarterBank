using System;
using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class CaixaSaqueDTO
    {
        [Required]
        public int ValorSaque { get; set; }
        public DateTime Data { get; set; }

    }
}