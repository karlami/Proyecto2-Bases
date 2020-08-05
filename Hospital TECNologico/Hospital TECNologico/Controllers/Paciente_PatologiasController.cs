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
    public class Paciente_PatologiasController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public Paciente_PatologiasController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Paciente_Patologias
        [Route("api/GetPaciente_Patologias")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente_Patologia>>> Getpaciente_patologia()
        {
            return await _context.paciente_patologia.ToListAsync();
        }

        /*
         * GETs de patologias de pacientes tienen que ser especificos a un solo paciente
         * se necesita una vista para retornar todos los que son solo de un idpaciente especifico.
         * Arreglar ambos GETs
         */

        // GET: api/Paciente_Patologias/5
        [Route("api/GetPaciente_Patologia/{id}")]
        [HttpGet]
        public async Task<ActionResult<Paciente_Patologia>> GetPaciente_Patologia(int id)
        {
            var paciente_Patologia = await _context.paciente_patologia.FindAsync(id);

            if (paciente_Patologia == null)
            {
                return NotFound();
            }

            return paciente_Patologia;
        }

        // PUT: api/Paciente_Patologias/5
        [Route("api/PutPaciente_Patologia")]
        [HttpPut]
        public async Task<IActionResult> PutPaciente_Patologia([FromForm] Paciente_Patologia paciente_Patologia)
        {
            /*if (id != paciente_Patologia.idpaciente)
            {
                return BadRequest();
            }*/

            _context.Entry(paciente_Patologia).State = EntityState.Modified;

            /*try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Paciente_PatologiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/

            return NoContent();
        }

        // POST: api/Paciente_Patologias
        [Route("api/PostPaciente_Patologia")]
        [HttpPost]
        public async Task<ActionResult<Paciente_Patologia>> PostPaciente_Patologia([FromForm] Paciente_Patologia paciente_Patologia)
        {
            _context.paciente_patologia.Add(paciente_Patologia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente_Patologia", new { id = paciente_Patologia.idpaciente }, paciente_Patologia);
        }

        /*
         * DELETE no funcionaria tampoco sin un id especifico de la tabla
         * o bien, con un delete con un where especifico del paciente y la patologia
         */

        // DELETE: api/Paciente_Patologias/5
        [Route("api/PostPaciente_Patologia/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Paciente_Patologia>> DeletePaciente_Patologia(int id)
        {
            var paciente_Patologia = await _context.paciente_patologia.FindAsync(id);
            if (paciente_Patologia == null)
            {
                return NotFound();
            }

            _context.paciente_patologia.Remove(paciente_Patologia);
            await _context.SaveChangesAsync();

            return paciente_Patologia;
        }

        private bool Paciente_PatologiaExists(int id)
        {
            return _context.paciente_patologia.Any(e => e.idpaciente == id);
        }
    }
}
