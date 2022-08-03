using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;
using StarterBank.Model.DTO;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class BancoController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public BancoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Retorna todos os bancos
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            try
            {
                var bancos = database.Bancos.Include(i => i.CaixasEletronicos).Include(c => c.Contas).ToList();

                if (bancos == null) { return NoContent(); }

                return Ok(bancos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar buscar bancos. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorno banco por id
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Get(int id)
        {
            try
            {
                var banco = database.Bancos.Include(i => i.CaixasEletronicos).Include(c => c.Contas).First(i => i.Id == id);

                if (banco == null) { return NoContent(); }

                return Ok(banco);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar buscar banco. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria um novo banco
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] BancoDTO model)
        {
            try
            {
                var bancoDados = database.Bancos.ToList();
                if (model.Faixa < 1000) { throw new Exception("A faixa precisa ser maior que 1000."); }
                if (model.Faixa > 9999) { throw new Exception("A faixa precisa ser menor que 10000."); }
                foreach (var item in bancoDados)
                {
                    if (item.Faixa == model.Faixa)
                    {
                        throw new Exception("Esta faixa já existe no banco de dados.");
                    }
                }
                Banco banco = new Banco();

                banco.Faixa = model.Faixa;
                banco.Nome = model.Nome;
                banco.NumeroAgencia = GeraNumeroConta.gerar();

                database.Add(banco);
                database.SaveChanges();
                return Ok(new { msg = "Banco cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar um novo Banco, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza o saçdp do banco
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, BancoDTO model)
        {
            try
            {
                var banco = database.Bancos.First(i => i.Id == id);
                var listaBancos = database.Bancos.ToList();
                var listaCaixa = database.CaixaEletronico.ToList();

                if (model.Faixa < 1000) { throw new Exception("A faixa precisa ser maior que 1000."); }
                if (model.Faixa > 9999) { throw new Exception("A faixa precisa ser menor que 10000."); }

                foreach (var caixa in listaCaixa)
                {
                    if (caixa.Id == model.CaixaEletronicoId)
                    {
                        banco.CaixasEletronicosId = model.CaixaEletronicoId;
                    }
                }

                foreach (var bancos in listaBancos)
                {
                    if (bancos.Faixa == model.Faixa)
                    {
                        throw new Exception("Esta faixa já existe no banco, tente outra.");
                    }
                }

                banco.Faixa = model.Faixa;
                banco.Nome = model.Nome;
                banco.NumeroAgencia = GeraNumeroConta.gerar();

                database.Update(banco);
                database.SaveChanges();
                return Ok(new { msg = "Banco atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar atualizar Banco, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um Banco por id, assim como contas, cartoes e clientes relacionados.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var banco = database.Bancos.First(i => i.Id == id);
                if (banco == null) { return NoContent(); }
                var caixas = database.CaixaEletronico.ToList();
                var contas = database.Contas.ToList();
                var clientes = database.Clientes.ToList();
                var cartoes = database.Cartoes.ToList();


                foreach (var item in caixas)
                {
                    if (item.BancoId == banco.Id)
                    {
                        database.Remove(item);
                    }
                }
                foreach (var conta in contas)
                {
                    if (conta.BancoId == banco.Id)
                    {

                        foreach (var cliente in clientes)
                        {
                            if (cliente.ContaId == conta.Id)
                            {
                                database.Remove(cliente);
                            }
                        }
                        database.Remove(conta);
                    }
                }

                foreach (var item in cartoes)
                {
                    if (item.BancoId == banco.Id)
                    {
                        database.Remove(item);
                    }
                }

                database.Remove(banco);
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