using Microsoft.AspNetCore.Mvc;
using StarterBank.Data;

namespace StarterBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContaController : ControllerBase
    {

        private readonly ApplicationDbContext database;
        public ContaController(ApplicationDbContext database)
        {
            this.database = database;
        }

    }
}