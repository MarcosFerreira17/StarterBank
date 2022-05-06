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
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ClienteController(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// retorna todos os clientes
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            try
            {
                var cliente = database.Clientes.ToList();

                if (cliente == null) { return NoContent(); }

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar buscar clientes. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorna um cliente por id
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var cliente = database.Clientes.First(i => i.Id == id);

                if (cliente == null) { return NoContent(); }

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar buscar cliente. Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ClienteDTO model)
        {
            try
            {
                Cliente cliente = new Cliente();

                if (CheckCPF.CPF(model.CPF) == false) { throw new Exception("CPF Inválido."); }

                cliente.Nome = model.Nome;
                cliente.Profissao = model.Profissao;
                cliente.CPF = model.CPF;
                cliente.ContaId = model.ContaId;

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
        /// <summary>
        /// Atualiza os dados do cliente por id
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] ClienteEditarDTO model)
        {
            try
            {
                var cliente = database.Clientes.First(i => i.Id == id);

                if (model == null) { return Ok(new { msg = "Nada for alterado" }); }

                cliente.Nome = model.Nome;
                cliente.Profissao = model.Profissao;

                database.Update(cliente);
                database.SaveChanges();
                return Ok(new { msg = "Cliente atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar atualizar Cliente, verifique os dados e tente novamente. Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Deleta um cliente por id
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = database.Clientes.First(i => i.Id == id);

                if (cliente == null) { return NoContent(); }

                database.Remove(cliente);

                database.SaveChanges();

                return Ok(new { msg = "Cliente deletado com sucesso." });
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar deletar cliente. Erro: {ex.Message}");
            }
        }


    }
}