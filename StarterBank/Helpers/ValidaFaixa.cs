using System;

namespace StarterBank.Helpers
{
    public class ValidaFaixa
    {
        public static bool Faixa(string faixaCartao, string faixaBanco)
        {
            if (faixaCartao.Length != 16) return false;

            if (faixaCartao.StartsWith(faixaBanco)) return true;

            return false;
        }
    }
}