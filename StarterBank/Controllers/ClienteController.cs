using System.Net;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();
                Cliente cliente = new Cliente();

                if (CheckCPF.CPF(model.CPF) == false) { return NoContent(); }

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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteEditarDTO model)
        {
            try
            {
                var dadosCliente = database.Clientes.ToList();

                Cliente cliente = new Cliente();

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

        [HttpDelete("{id}")]
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