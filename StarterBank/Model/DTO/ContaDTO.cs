using System.ComponentModel.DataAnnotations;

namespace StarterBank.Model
{
    public class ContaDTO
    {
        public int Id { get; set; }
        public int BancoId { get; set; }
        public int NumeroConta { get; set; }
        public float Saldo { get; set; }
        public int CartaoId { get; set; }
        public int CaixaEletronicoId { get; set; }

    }
}