namespace StarterBank.Model
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public string CPF { get; set; }
        public Conta Conta { get; set; }
        
        
    }
}