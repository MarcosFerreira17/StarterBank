namespace StarterBank.Helpers
{
    public class ValidaSaque
    {
        public static bool Valor(int valor)
        {
            return valor % 10 == 0;
        }
    }
}