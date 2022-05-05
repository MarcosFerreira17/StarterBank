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
                var contas = database.Contas.ToList();

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
                var conta = database.Contas.First(i => i.Id == id);

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

                conta.BancoId = model.BancoId;
                conta.ClienteId = model.ClienteId;
                conta.NumeroConta = 1234;
                conta.Saldo = model.SaldoInicial;

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
        public IActionResult PutSaque([FromBody] ContaRegistroDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();
                Conta conta = new Conta();

                conta.BancoId = model.BancoId;
                conta.ClienteId = model.ClienteId;
                conta.NumeroConta = 1234;
                conta.Saldo = model.SaldoInicial;

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
                var conta = database.Contas.First(i => i.Id == id);
                if (conta == null) { return NoContent(); }

                database.Remove(conta);
                database.SaveChanges();
                return Ok(new { msg = "Conta deletada com sucecesso." });

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
              $"Erro ao tentar deletar conta. Erro: {ex.Message}");

            }
        }

    }
}