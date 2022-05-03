namespace StarterBank.Model
{
    public class Conta
    {
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string Numero { get; set; }
        public int Agencia { get; set; }
        public float Saldo { get; set; }
        public Cartao cartao { get; set; }
    }
}