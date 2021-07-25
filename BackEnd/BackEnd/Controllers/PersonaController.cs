using BackEnd.Models;
using BackEnd.Repositories.Interfaces;
using BackEnd.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly IPersonaCollection  db = new PersonaCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {

            return Ok(await db.ToList());
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetPersonaDetails(string id)
        {
            return Ok(await db.GetById(id));
        }
       

        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            if(persona.Primer_Nombre == string.Empty)
            {
                ModelState.AddModelError("Primer Nombre", "El Primer nombre no puede ser vacio");
            }

            await db.Insert(persona);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona([FromBody] Persona persona, string id)
        {
            if (persona == null)
                return BadRequest();

            if (persona.Primer_Nombre == string.Empty)
            {
                ModelState.AddModelError("Primer Nombre", "El Primer nombre no puede ser vacio");
            }


            persona.Id = new ObjectId(id);

            await db.Update(persona);
            return Created("Created", true);

        }


        [HttpDelete]
        public async Task<IActionResult> DeletePersona(string id)
        {
            await db.Delete(id);
            return NoContent(); //success
        }



    }
}
