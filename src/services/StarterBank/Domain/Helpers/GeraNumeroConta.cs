using System;

namespace StarterBank.Helpers
{
    public class GeraNumeroConta
    {
        public static string gerar()
        {
            string characters = "1234567890";
            var transformChar = characters.Replace(" ", "").ToUpper();

            var Charsarr = new char[6];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = transformChar[random.Next(transformChar.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }
    }
}