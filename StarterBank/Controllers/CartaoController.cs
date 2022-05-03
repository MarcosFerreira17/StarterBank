using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;

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

    }
}