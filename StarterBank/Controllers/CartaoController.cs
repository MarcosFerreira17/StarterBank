using System.Net;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;
using Microsoft.AspNetCore.Authorization;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartaoController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public CartaoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        //   [Authorize]
        public IActionResult Get()
        {
            try
            {
                var cartao = database.Cartoes.ToList();
                return Ok(cartao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar registrar um novo usuário, verifique a conta vinculada ao cartão e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        //     [Authorize("admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var cartao = database.Cartoes.First(i => i.Id == id);
                return Ok(cartao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar registrar um novo usuário, verifique a conta vinculada ao cartão e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpPost("{id}")]
        //  [Authorize("admin")]
        public IActionResult Post(int id, [FromBody] CartaoRegistroDTO model)
        {
            try
            {
                var conta = database.Contas.First(i => i.Id == id);

                if (conta == null) { return NoContent(); }

                Cartao cartao = new Cartao();

                cartao.Numero = GeraNumeroCartao.Generate(conta.Banco.Faixa);
                cartao.Senha = EncriptPassword.Encripted(model.Senha);
                cartao.Role = "user_comum";

                database.Add(cartao);
                database.SaveChanges();
                return Ok(new { msg = "Cartão cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar um novo cartão, verifique a conta vinculada ao cartão e tente novamente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CartaoRegistroDTO model)
        {
            try
            {
                var cartao = database.Cartoes.First(i => i.Id == id);
                EncriptPassword.Encripted(model.Senha);
                cartao.Senha = EncriptPassword.Encripted(model.Senha);
                return Ok(new { msg = "Senha alterada" });

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao atualizar senha do cartão. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var cartao = database.Cartoes.First(i => i.Id == id);

                database.Remove(cartao);
                database.SaveChanges();
                return Ok(cartao + " Deletado com sucesso.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao deletar cartão. Erro: {ex.Message}");
            }
        }

    }
}