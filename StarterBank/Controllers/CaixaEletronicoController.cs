using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Model;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CaixaEletronicoController : ControllerBase
    {

        private readonly ApplicationDbContext database;
        public CaixaEletronicoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult GetCaixas()
        {
            try
            {
                var caixa = database.CaixaEletronico.ToList();
                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar depositar saldo no caixa. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCaixaId(int id)
        {
            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);
                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar depositar saldo no caixa. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult NovoCaixa([FromBody] CaixaDepositoDTO model)
        {
            try
            {
                if (model == null) return NoContent();

                CaixaEletronico caixa = new CaixaEletronico();
                caixa.Data = DateTime.Now;
                caixa.nota10 = model.nota10;
                caixa.nota20 = model.nota20;
                caixa.nota50 = model.nota50;
                caixa.nota100 = model.nota100;
                caixa.Saldo += model.nota10 * Cedula.Dez + model.nota20 * Cedula.Vinte + model.nota50 * Cedula.Cinquenta + model.nota100 * Cedula.Cem;

                if (caixa.Saldo <= 0) return NoContent();

                database.Add(caixa);
                database.SaveChanges();

                return Ok(caixa.Saldo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar criar novo caixa eletronico. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AdicionaSaldo(int id, [FromBody] CaixaDepositoDTO model)
        {
            try
            {
                if (model == null) return NoContent();

                var caixa = database.CaixaEletronico.First(i => i.Id == id);
                caixa.Data = DateTime.Now; //Horario atual da operação.
                caixa.nota10 += model.nota10;
                caixa.nota20 += model.nota20;
                caixa.nota50 += model.nota50;
                caixa.nota100 += model.nota100;
                caixa.Saldo += model.nota10 * Cedula.Dez + model.nota20 * Cedula.Vinte + model.nota50 * Cedula.Cinquenta + model.nota100 * Cedula.Cem;

                database.Update(caixa);
                database.SaveChanges();

                return Ok(caixa.Saldo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar depositar saldo no caixa. Erro: {ex.Message}");
            }
        }

        [HttpPost("{id}")]
        public IActionResult Saque(int id, [FromBody] CaixaSaqueDTO model)
        {

            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);

                var cedulasSacadas = new List<int>();
                int valorRestanteASerSacado = model.ValorSaque;

                while (valorRestanteASerSacado >= Cedula.Cem)
                {
                    cedulasSacadas.Add(Cedula.Cem);
                    caixa.nota100 -= 1;
                    caixa.Saldo -= Cedula.Cem;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cem;
                }

                while (valorRestanteASerSacado >= Cedula.Cinquenta)
                {
                    cedulasSacadas.Add(Cedula.Cinquenta);
                    caixa.nota50 -= 1;
                    caixa.Saldo -= Cedula.Cinquenta;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cinquenta;
                }

                while (valorRestanteASerSacado >= Cedula.Vinte)
                {
                    cedulasSacadas.Add(Cedula.Vinte);
                    caixa.nota20 -= 1;
                    caixa.Saldo -= Cedula.Vinte;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Vinte;
                }

                while (valorRestanteASerSacado >= Cedula.Dez)
                {
                    cedulasSacadas.Add(Cedula.Dez);
                    caixa.nota10 -= 1;
                    caixa.Saldo -= Cedula.Dez;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Dez;
                }
                if (cedulasSacadas.Count == 0)
                    throw new Exception("Não há cedulas disponíveis para o valor solicitado.");

                caixa.ValorSaque += model.ValorSaque; //Valor sacado total
                database.Update(caixa);
                database.SaveChanges();
                return Ok(cedulasSacadas);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar sacar no caixa. Erro: {ex.Message}");
            }
        }

        [HttpPost("{id}")]
        public IActionResult DeletarCaixa(int id, [FromBody] CaixaSaqueDTO model)
        {

            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);

                var cedulasSacadas = new List<int>();
                int valorRestanteASerSacado = model.ValorSaque;

                while (valorRestanteASerSacado >= Cedula.Cem)
                {
                    cedulasSacadas.Add(Cedula.Cem);
                    caixa.nota100 -= 1;
                    caixa.Saldo -= Cedula.Cem;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cem;
                }

                while (valorRestanteASerSacado >= Cedula.Cinquenta)
                {
                    cedulasSacadas.Add(Cedula.Cinquenta);
                    caixa.nota50 -= 1;
                    caixa.Saldo -= Cedula.Cinquenta;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Cinquenta;
                }

                while (valorRestanteASerSacado >= Cedula.Vinte)
                {
                    cedulasSacadas.Add(Cedula.Vinte);
                    caixa.nota20 -= 1;
                    caixa.Saldo -= Cedula.Vinte;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Vinte;
                }

                while (valorRestanteASerSacado >= Cedula.Dez)
                {
                    cedulasSacadas.Add(Cedula.Dez);
                    caixa.nota10 -= 1;
                    caixa.Saldo -= Cedula.Dez;
                    valorRestanteASerSacado = valorRestanteASerSacado - Cedula.Dez;
                }
                if (cedulasSacadas.Count == 0)
                    throw new Exception("Não há cedulas disponíveis para o valor solicitado.");

                caixa.ValorSaque += model.ValorSaque; //Valor sacado total
                database.Update(caixa);
                database.SaveChanges();
                return Ok(cedulasSacadas);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar sacar no caixa. Erro: {ex.Message}");
            }
        }


        //Guarda o valor da cedula
        public static class Cedula
        {
            public static int Cem => 100;
            public static int Cinquenta => 50;
            public static int Vinte => 20;
            public static int Dez => 10;
        }

    }

}

