namespace StarterBank.Model
{
    public class Extrato
    {
        public int Id { get; set; }
        public int BancoId { get; set; }
        public int ContaId { get; set; }
        public int ValorDoSaque { get; set; }
        public int ValorDoDeposito { get; set; }

    }
}