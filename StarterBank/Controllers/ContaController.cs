using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Model;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContaController : ControllerBase
    {

        private readonly ApplicationDbContext database;
        public ContaController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var contas = database.Contas.Include(c => c.Cartao).Include(c => c.Caixa).ToList();

                if (contas == null) { return NoContent(); }

                return Ok(contas);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar buscar contas. Erro: {ex.Message}");

            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                var conta = database.Contas.Include(c => c.Cartao).Include(c => c.Caixa).First(i => i.Id == id);

                if (conta == null) { return NoContent(); }

                return Ok(conta);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar buscar conta. Erro: {ex.Message}");

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContaRegistroDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();
                Conta conta = new Conta();

                conta.NumeroAgencia = model.Agencia;
                conta.NomeBanco = model.NomeBanco;
                conta.NumeroConta = model.Numero;
                conta.Saldo = model.Saldo;
                conta.Cartao.Id = model.CartaoId;

                database.Add(conta);
                database.SaveChanges();
                return Ok(new { msg = "Conta cadastrada com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar uma nova Conta, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put([FromBody] ContaRegistroDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();
                Conta conta = new Conta();

                conta.NumeroAgencia = model.Agencia;
                conta.NomeBanco = model.NomeBanco;
                conta.NumeroConta = model.Numero;
                conta.Saldo = model.Saldo;
                conta.Cartao.Id = model.CartaoId;

                database.Add(conta);
                database.SaveChanges();
                return Ok(new { msg = "Conta editada com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar uma nova Conta, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var conta = database.Contas.Include(c => c.Cartao).Include(c => c.Caixa).First(i => i.Id == id);
                var cartao = database.Cartoes.First(i => i.Id == conta.Cartao.Id);

                if (conta == null) { return NoContent(); }

                database.Remove(conta);
                database.Remove(cartao);
                database.SaveChanges();
                return Ok(conta);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar deletar conta. Erro: {ex.Message}");

            }
        }

        // [HttpPost("{id}")]
        // public IActionResult Saque([FromBody] ContaDTO model)
        // {

        // }


    }
}