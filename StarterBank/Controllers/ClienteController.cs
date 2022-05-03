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
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ClienteController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteRegistroDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();
                Cliente cliente = new Cliente();

                if (CheckCPF.CPF(model.CPF) == false) { return NoContent(); }

                cliente.Nome = model.Nome;
                cliente.Profissao = model.Profissao;
                cliente.CPF = model.CPF;

                database.Add(cliente);
                database.SaveChanges();
                return Ok(new { msg = "Cliente cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar registrar um novo Cliente, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }

    }
}