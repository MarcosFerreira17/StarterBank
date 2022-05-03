using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Model;

namespace StarterBank.Controller
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
        public IActionResult GetExtrato()
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
        public IActionResult getSaldoId(int id)
        {
            try
            {
                var caixa = database.CaixaEletronico.Include(c => c.Cartao).First(i => i.Id == id);
                return Ok(caixa.Saldo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar depositar saldo no caixa. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult putSaldo([FromBody] CaixaDepositoDTO model)
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
                caixa.Saldo += model.nota10 * 10 + model.nota20 * 20 + model.nota50 * 50 + model.nota100 * 100;
                
                if (caixa.Saldo <= 0) return NoContent();

                database.Add(caixa);
                database.SaveChanges();

                return Ok(caixa.Saldo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar depositar saldo no caixa. Erro: {ex.Message}");
            }
        }
    }
}