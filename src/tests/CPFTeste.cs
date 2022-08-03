using StarterBank.Helpers;
using Xunit;

namespace StarterBank.TDD
{
    public class TestaCPF
    {
        [Theory]
        [InlineData("46680074800")]
        [InlineData("466.800.748-00")]
        [InlineData("466.800.748.00")]
        [InlineData("466.800.74800")]
        [InlineData("466800748-00")]
        public void CPF_Valido(string cpf)
        {
            Assert.True(CheckCPF.CPF(cpf));
        }

        [Theory]
        [InlineData("12354687955")]
        [InlineData("123.546.879-55")]
        [InlineData("1.2.3.5.4.6.8.7.9.5.5.")]
        [InlineData("")]
        [InlineData("333")]
        [InlineData("123456")]
        [InlineData("123456789")]
        public void CPF_Invalido(string cpf)
        {
            Assert.False(CheckCPF.CPF(cpf));
        }

    }
}
