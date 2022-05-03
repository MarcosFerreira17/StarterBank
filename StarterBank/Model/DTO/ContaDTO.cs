namespace StarterBank.Model
{
    public class ContaDTO
    {
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string Numero { get; set; }
        public int Agencia { get; set; }
        public float Saldo { get; set; }
        public Cartao Cartao { get; set; }
        public int CartaoId { get; set; }

    }
}