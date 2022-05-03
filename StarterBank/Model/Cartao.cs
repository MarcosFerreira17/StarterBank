namespace StarterBank.Model
{
    public class Cartao
    {
        public int Id { get; set; }
        public long Numero { get; set; }
        public float Saldo { get; set; }
        public string Senha { get; set; }
        public Conta Conta { get; set; }
        
    }
}