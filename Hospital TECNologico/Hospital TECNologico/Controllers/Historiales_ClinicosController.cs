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
    public class Historiales_ClinicosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public Historiales_ClinicosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Historiales_Clinicos
        [Route("api/GetHistoriales_Clinicos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial_Clinico>>> Gethistorial_clinico()
        {
            return await _context.historial_clinico.ToListAsync();
        }

        // GET: api/Historiales_Clinicos/5
        [Route("api/GetHistorial_Clinico/{id}")]
        [HttpGet]
        public async Task<ActionResult<Historial_Clinico>> GetHistorial_Clinico(int id)
        {
            var historial_Clinico = await _context.historial_clinico.FindAsync(id);

            if (historial_Clinico == null)
            {
                return NotFound();
            }

            return historial_Clinico;
        }

        // PUT: api/Historiales_Clinicos/5
        [Route("api/PutHistorial_Clinico")]
        [HttpPut]
        public async Task<IActionResult> PutHistorial_Clinico([FromForm] Historial_Clinico historial_clinico)
        {
            /*if (id != historial_Clinico.idhistorial)
            {
                return BadRequest();
            }*/

            _context.Entry(historial_clinico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Historial_ClinicoExists(historial_clinico.idhistorial))
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

        // POST: api/Historiales_Clinicos
        [Route("api/PostHistorial_Clinico")]
        [HttpPost]
        public async Task<ActionResult<Historial_Clinico>> PostHistorial_Clinico([FromForm] Historial_Clinico historial_clinico)
        {
            _context.historial_clinico.Add(historial_clinico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorial_Clinico", new { id = historial_clinico.idhistorial }, historial_clinico);
        }

        // DELETE: api/Historiales_Clinicos/5
        [Route("api/PutHistorial_Clinico/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Historial_Clinico>> DeleteHistorial_Clinico(int id)
        {
            var historial_Clinico = await _context.historial_clinico.FindAsync(id);
            if (historial_Clinico == null)
            {
                return NotFound();
            }

            _context.historial_clinico.Remove(historial_Clinico);
            await _context.SaveChangesAsync();

            return historial_Clinico;
        }

        private bool Historial_ClinicoExists(int id)
        {
            return _context.historial_clinico.Any(e => e.idhistorial == id);
        }
    }
}
