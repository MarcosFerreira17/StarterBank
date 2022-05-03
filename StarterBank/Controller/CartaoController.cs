using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarterBank.Data;
using StarterBank.Model;

namespace StarterBank.Controller
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