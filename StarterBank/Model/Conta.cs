using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public Banco Banco { get; set; }
        public int NumeroConta { get; set; }
        public float Saldo { get; set; }
        public int CartaoId { get; set; }
        public int CaixaEletronicoId { get; set; }
    }
}