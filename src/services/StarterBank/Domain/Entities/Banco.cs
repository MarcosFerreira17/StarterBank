using System.Collections.Generic;

namespace StarterBank.Model
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Faixa { get; set; }
        public string NumeroAgencia { get; set; }
        public List<CaixaEletronico> CaixasEletronicos { get; set; }
        public int CaixasEletronicosId { get; set; }
        public List<Conta> Contas { get; set; }

    }
}