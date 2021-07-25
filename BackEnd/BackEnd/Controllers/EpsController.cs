using BackEnd.Repositories.Interfaces;
using BackEnd.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpsController : Controller
    {
        private readonly IEpsCollection db = new EpsCollection();


        [HttpGet]
        public async Task<IActionResult> GetAllEps()
        {
            return Ok(await db.ToList());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEpsDetail(string id)
        {
            return Ok(await db.GetById(id));
        }
    }
}
