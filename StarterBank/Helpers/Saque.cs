using System.Collections.Generic;
using StarterBank.Model.DTO;

namespace StarterBank.Helpers
{
    public class Saque
    {
        public static List<int> Valor(int valor)
        {
            var cedulasSacadas = new List<int>();
            int valorRestanteASerSacado = valor;

            while (valorRestanteASerSacado >= Cedula.Cem)
            {
                cedulasSacadas.Add(Cedula.Cem);
                valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cem;
            }

            while (valorRestanteASerSacado >= Cedula.Cinquenta)
            {
                cedulasSacadas.Add(Cedula.Cinquenta);
                valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cinquenta;
            }

            while (valorRestanteASerSacado >= Cedula.Vinte)
            {
                cedulasSacadas.Add(Cedula.Vinte);
                valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Vinte;
            }

            while (valorRestanteASerSacado >= Cedula.Dez)
            {
                cedulasSacadas.Add(Cedula.Dez);
                valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Dez;
            }
            if (cedulasSacadas.Count == 0)
                throw new System.Exception("Não há cedulas disponíveis para o valor solicitado.");

            return cedulasSacadas;
        }
    }
}