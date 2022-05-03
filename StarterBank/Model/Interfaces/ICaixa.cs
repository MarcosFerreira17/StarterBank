using System.Collections.Generic;

namespace StarterBank.Model.Interfaces
{
    public interface ICaixa
    {
        ICollection<int> Saque(int valor);
        bool ValidaCedulasDisponiveis(int valor);
    }
}