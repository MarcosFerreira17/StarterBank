using System;

namespace StarterBank.Helpers
{
    public class GeraNumeroCartao
    {
        public static string Faixa(int faixaBanco)
        {
            var characters = "123456789012";

            var Charsarr = new char[12];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            resultString = faixaBanco + resultString;

            return resultString;
        }
    }
}