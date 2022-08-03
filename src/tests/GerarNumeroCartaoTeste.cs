using Xunit;
using StarterBank.Helpers;

namespace StarterBank.TDD
{
    public class GerarNumeroCartaoTeste
    {
        [Theory(Skip = "Não implementado.")]
        [InlineData(1234)]
        public void GerarNumeroCartao(int faixaCartao)
        {
            string nmrCartao = GeraNumeroCartao.Faixa(faixaCartao);
            var expected = faixaCartao.ToString();
            Assert.Contains(expected, nmrCartao);
        }

    }
}
