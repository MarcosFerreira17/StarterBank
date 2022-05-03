using System;

namespace StarterBank.Model.DTO
{
    public class CaixaEletronicoDTO
    {
        public int nota100 { get; set; }
        public int nota50 { get; set; }
        public int nota20 { get; set; }
        public int nota10 { get; set; }
        public string Banco { get; set; }
        public int FaixaDoBanco { get; set; }
    }
}