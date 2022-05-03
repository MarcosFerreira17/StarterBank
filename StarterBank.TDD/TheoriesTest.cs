using StarterBank.Controllers;
using StarterBank.Model;
using Xunit;

namespace StarterBank.TDD
{
    public class TheoriesTest
    {
        private readonly CaixaEletronicoController caixa;
        private readonly CaixaSaqueDTO saque;

        [Theory(DisplayName = "Saque contém número de cedulas solicitado correto")]
        [InlineData(3, 80)]
        [InlineData(3, 300)]
        [InlineData(5, 500)]
        public void Saque_Contem_Numero_De_Cedulas_Correto(int quantidadeDeCedulas, int valorDoSaque)
        {
            // var resultadoCedulas = caixa.Saque(valorDoSaque);
            // Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }
    }
}