using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        // [HttpPost("{id}")]
        // public IActionResult Saque([FromBody] ContaDTO model)
        // {

        // }


    }
}