using System;

namespace StarterBank.Helpers
{
    public class GeraNumeroCartao
    {
        public static string Generate(string FaixaDoBanco)
        {
            var characters = "123456789012";
            var transformChar = characters.Replace(" ", "").ToUpper();

            var Charsarr = new char[12];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = transformChar[random.Next(transformChar.Length)];
            }

            var resultString = new String(Charsarr);
            resultString = FaixaDoBanco + resultString;
            return resultString;
        }
    }
}