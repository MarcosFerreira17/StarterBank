using StarterBank.Helpers;
using Xunit;
using System;

namespace StarterBank.TDD
{
    public class SaqueTeste
    {

        private readonly Saque saque;

        [Theory]
        [InlineData(500)]
        [InlineData(50)]
        [InlineData(150)]
        [InlineData(20)]
        [InlineData(10)]
        [InlineData(510)]
        public void Saque_Valido(int valorDoSaque)
        {
            bool saqueEhValido = ValidaSaque.Valor(valorDoSaque);
            Assert.True(saqueEhValido);//verifica se resultado esperado é verdadeiro
        }

        [Theory]
        [InlineData(5)]
        [InlineData(2)]
        [InlineData(22)]
        [InlineData(25)]
        [InlineData(105)]
        [InlineData(204)]
        public void Saque_Invalido(int valorDoSaque)
        {
            bool saqueEhValido = ValidaSaque.Valor(valorDoSaque);
            Assert.False(saqueEhValido);//verifica se resultado esperado é verdadeiro
        }

        [Fact]
        public void Deve_Gerar_Excecao()
        {
            int valorDoSaque = 5;
            Assert.Throws<Exception>(() => Saque.Valor(valorDoSaque));//verifica se método lança exceção
        }

    }
}
