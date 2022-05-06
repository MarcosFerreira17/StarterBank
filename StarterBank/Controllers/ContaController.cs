using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ContaController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        private readonly CaixaEletronicoController _caixaController;
        private readonly ExtratoController _extratoController;
        public ContaController(ApplicationDbContext database)
        {
            this.database = database;
            _extratoController = new ExtratoController(database);
            _caixaController = new CaixaEletronicoController(database);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ContaRegistroDTO model)
        {
            try
            {
                Conta conta = new Conta();

                conta.BancoId = model.BancoId;
                conta.ClienteId = model.ClienteId;
                conta.NumeroConta = GeraNumeroConta.gerar();
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

        [HttpPost("{id}")]
        public IActionResult Saque(int id, [FromForm] int valor)
        {
            try
            {
                if (ValidaSaque.Valor(valor) != true)
                {
                    throw new Exception("O caixa trabalha somente com as seguintes notas: R$ 10 R$20 R$50 R$100.");
                }

                var conta = database.Contas.First(i => i.Id == id);
                var banco = database.Bancos.First(i => i.Id == conta.BancoId);
                var cartao = database.Cartoes.First(i => i.BancoId == banco.Id);

                if (ValidaFaixa.Faixa(cartao.Numero, banco.Faixa.ToString()) == false)
                {
                    throw new Exception("O seu cartão não confere com este caixa eletronico, verifique a faixa do seu Banco e tente novamente.");
                }

                if (conta.Saldo >= valor)
                {
                    _caixaController.PostByIdSaque(banco.CaixasEletronicosId, valor);
                    conta.Saldo -= valor;
                    database.Update(conta);
                    database.SaveChanges();
                    _extratoController.Post(conta.BancoId, conta.Id, valor, 0);
                    return Ok(new { msg = "Realizado com sucesso o saque no valor de R$" + valor.ToString("f2") });
                }
                else
                {
                    throw new Exception("O valor excede o saldo da conta.");
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar saque, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] ContaRegistroDTO model)
        {
            try
            {
                var conta = database.Contas.First(i => i.Id == id);

                conta.BancoId = model.BancoId;
                conta.ClienteId = model.ClienteId;
                conta.NumeroConta = GeraNumeroConta.gerar();
                conta.Saldo = model.SaldoInicial;

                database.Update(conta);
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
        [Authorize(Roles = "admin")]
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