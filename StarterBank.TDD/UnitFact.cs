using System;
using StarterBank.Model;
using Xunit;

namespace StarterBank.TDD
{
    public class UnitTest
    {
        private readonly Caixa caixa = new Caixa();

        [Fact]
        public void Saque_Valido()
        {
            //Arrange
            int valorDoSaque = 30;
            bool result = caixa.ValidaCedulasDisponiveis(valorDoSaque);
            //Act
            //Assert
            Assert.True(result); //verifica se resultado esperado é verdadeiro
        }

        [Fact]
        public void Deve_Gerar_Excecao()
        {
            int valorDoSaque = 5;
            Assert.Throws<Exception>(() => caixa.Saque(valorDoSaque)); //verifica se método lança exceção
        }

    }
}
