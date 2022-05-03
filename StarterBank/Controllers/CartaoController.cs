using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;

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

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] CartaoRegistroDTO cartaoModel)
        {
            try
            {
                var cartaoData = database.Cartoes.ToList();
                var conta = database.Contas.First(i => i.Id == id);

                Cartao cartao = new Cartao();

                string EncriptPasswordUser = EncriptPassword.Encripted(cartaoModel.Senha);

                cartao.Numero = GeraNumeroCartao.Generate("1234");
                cartao.Senha = EncriptPasswordUser;

                database.Add(cartao);
                database.SaveChanges();
                return Ok(new { msg = "Usuário cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar um novo usuário, verifique a conta vinculada ao cartão e tente novamente. Erro: {ex.Message}");
            }
        }

    }
}