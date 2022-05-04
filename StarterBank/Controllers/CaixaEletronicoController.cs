using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;
using StarterBank.Model.DTO;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Get()
        {
            try
            {
                var caixa = database.CaixaEletronico.ToList();
                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar buscar lista de caixas caixa. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);
                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar encontrar caixa. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostNovoCaixa([FromBody] CaixaEletronicoDTO model)
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
                caixa.Banco = model.Banco;
                caixa.FaixaDoBanco = model.FaixaDoBanco;
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
        public IActionResult PutDeposito(int id, [FromBody] CaixaEletronicoDTO model)
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
                caixa.Banco = model.Banco;
                caixa.FaixaDoBanco = model.FaixaDoBanco;
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
        public IActionResult PostByIdSaque(int id, [FromForm] int valor)
        {
            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);

                if (ValidaSaque.Valor(valor) != true)
                {
                    throw new Exception("O caixa trabalha somente com as seguintes notas: R$ 10 R$20 R$50 R$100.");
                }

                var nota = Saque.Valor(valor);

                for (var i = 0; i < nota.Count; i++)
                {
                    if (nota[i] == Cedula.Cem) { caixa.nota100 -= 1; }
                    if (nota[i] == Cedula.Cinquenta) { caixa.nota50 -= 1; }
                    if (nota[i] == Cedula.Vinte) { caixa.nota20 -= 1; }
                    if (nota[i] == Cedula.Dez) { caixa.nota10 -= 1; }
                }

                caixa.ValorSaque += valor; //Valor sacado total
                caixa.Saldo -= valor;
                database.Update(caixa);
                database.SaveChanges();
                return Ok(new { msg = "Valor sacado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var caixa = database.CaixaEletronico.First(i => i.Id == id);

                database.Remove(caixa);
                database.SaveChanges();
                return Ok(caixa + " Deletado com sucesso.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao deletar caixa eletronico. Erro: {ex.Message}");
            }
        }

    }

}

