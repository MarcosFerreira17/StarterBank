using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StarterBank.Data;
using StarterBank.Helpers;
using StarterBank.Model;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public AuthenticationController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Acesso([FromBody] CartaoLoginDTO credentials)
        {
            string EncriptPasswordUser = EncriptPassword.Encripted(credentials.Senha);
            try
            {
                Cartao cartao = database.Cartoes.First(u => u.Numero.Equals(credentials.Numero));

                if (cartao == null) { return NoContent(); }

                if (cartao.Senha.Equals(EncriptPasswordUser))
                {
                    // Definindo uma chave de segurança.
                    string securityKey = "starterbank_api_rest_projeto_starter";
                    //convertendo a chave de segurança em um array de bytes para conseguir gerar uma chame simé
                    var symmectricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                    var credentialsForAccess = new SigningCredentials(symmectricKey, SecurityAlgorithms.HmacSha256Signature);

                    var claims = new List<Claim>();
                    claims.Add(new Claim("numero", cartao.Numero.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, cartao.Role));

                    var JWT = new JwtSecurityToken(
                        issuer: "STARTERBANKAPI", // Quem está fornecendo o jwt para o usuário.
                        expires: DateTime.Now.AddMinutes(15), // Quando o token expira.
                        audience: "usuario_comum", // Pra quem é destinado este token.
                        signingCredentials: credentialsForAccess, // Credenciais de acesso.
                        claims: claims
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(JWT));
                }
                else
                {
                    Response.StatusCode = 401;
                    return new ObjectResult("");
                }

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar acessar conta. Erro: {ex.Message}");
            }

        }
    }
}
