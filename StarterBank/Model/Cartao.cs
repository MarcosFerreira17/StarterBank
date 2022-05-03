namespace StarterBank.Model
{
    public class Cartao
    {
        public int Id { get; set; }
        public long Numero { get; set; }
        public Cliente Cliente { get; set; }
        public string Senha { get; set; }

    }
}