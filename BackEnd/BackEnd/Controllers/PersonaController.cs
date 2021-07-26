using BackEnd.Models;
using BackEnd.Repositories.Helpers;
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
        public async Task<HttpResponserWrapper<Persona>> CreatePersona([FromBody] Persona persona)
        {
           
            if(persona.Primer_Nombre == string.Empty)
            {
                ModelState.AddModelError("Primer Nombre", "El Primer nombre no puede ser vacio");
            }

            persona.Schema_version = 1.ToString();
            persona.Document_version = 1.ToString();
            var response = await db.Insert(persona);
            return response;
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


            persona.Id = id;
            

            await db.Update(persona);
            return Created("Created", true);

        }

        [Route("Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(string id)
        {
            await db.Delete(id);
            return NoContent(); //success
        }



    }
}
