using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ExtratoController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ExtratoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            try
            {
                var extrato = database.Extratos.ToList();

                if (extrato == null) { return NoContent(); }

                return Ok(extrato);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar buscar extratos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var extrato = database.Extratos.First(i => i.Id == id);

                if (extrato == null) { return NoContent(); }

                return Ok(extrato);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar buscar extrato. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post(int bancoId, int contaId, int valorSaque, int ValorDoDeposito)
        {
            try
            {
                Extrato extrato = new Extrato();

                extrato.BancoId = bancoId;
                extrato.ContaId = contaId;
                extrato.ValorDoSaque = valorSaque;
                extrato.ValorDoDeposito = ValorDoDeposito;

                database.Add(extrato);
                database.SaveChanges();
                return Ok(extrato);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar um novo extrato, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var extrato = database.Extratos.First(i => i.Id == id);

                if (extrato == null) { return NoContent(); }

                database.Remove(extrato);

                database.SaveChanges();

                return Ok(new { msg = "Extrato deletado com sucesso." });
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar deletar extrato. Erro: {ex.Message}");
            }
        }


    }
}