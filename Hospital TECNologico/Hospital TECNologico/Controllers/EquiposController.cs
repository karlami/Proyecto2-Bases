using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_TECNologico.Data;
using Hospital_TECNologico.Models;

namespace Hospital_TECNologico.Controllers
{
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public EquiposController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Equipos
        [Route("api/GetEquipos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipo()
        {
            return await _context.equipo.ToListAsync();
        }

        // GET: api/Equipos/5
        [Route("api/GetEquipo/{id}")]
        [HttpGet]
        public async Task<ActionResult<Equipo>> GetEquipo(int id)
        {
            var equipo = await _context.equipo.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        // PUT: api/Equipos/5
        [Route("api/PutEquipo")]
        [HttpPut]
        public async Task<IActionResult> PutEquipo([FromForm] Equipo equipo)
        {
            /*if (id != equipo.idequipo)
            {
                return BadRequest();
            }*/

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(equipo.idequipo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Equipos
        [Route("api/PostEquipo")]
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo([FromForm] Equipo equipo)
        {
            _context.equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.idequipo }, equipo);
        }

        // DELETE: api/Equipos/5
        //Not needed, yet
        [Route("api/DeleteEquipo/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Equipo>> DeleteEquipo(int id)
        {
            var equipo = await _context.equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.equipo.Remove(equipo);
            await _context.SaveChangesAsync();

            return equipo;
        }

        private bool EquipoExists(int id)
        {
            return _context.equipo.Any(e => e.idequipo == id);
        }
    }
}
