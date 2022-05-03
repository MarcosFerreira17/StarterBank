using System;

namespace StarterBank.Model
{
    public class CaixaSaqueDTO
    {
        public int nota100 { get; set; }
        public int nota50 { get; set; }
        public int nota20 { get; set; }
        public int nota10 { get; set; }
        public int ValorSaque { get; set; }
        public DateTime Data { get; set; }
        public Cartao Cartao { get; set; }
    
    }
}