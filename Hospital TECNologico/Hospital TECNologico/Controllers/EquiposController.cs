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
    /*
     * Controlador de Equipo Medico
     * Recibe las solicitudes para Ingresar, Mostrar y Modificar estos de la base de datos.
     */
    [ApiController]
    public class EquiposController : ControllerBase
    {
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de EquiposController
         */
        public EquiposController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetEquipos"
         * Obtiene todos los equipos medicos en la base de datos
         */
        [Route("api/GetEquipos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipo()
        {
            return await _context.equipo.ToListAsync();
        }

        /*
         * GET: "api/GetEquipo/idEquipo"
         * Obtiene solo el equipo medico con el idequipo indicado
         */
        [Route("api/GetEquipo/{idEquipo}")]
        [HttpGet]
        public async Task<ActionResult<Equipo>> GetEquipo(int idEquipo)
        {
            var equipo = await _context.equipo.FindAsync(idEquipo);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        /*
         * PUT: "api/PutEquipo"
         * Actualiza un equipo medico con el idequipo que se indica en el Form.
         */
        [Route("api/PutEquipo")]
        [HttpPut]
        public async Task<IActionResult> PutEquipo([FromBody] Equipo equipo)
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

        /*
         * POST: "api/PostEquipo"
         * Agregar un equipo medico nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostEquipo")]
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo([FromBody] Equipo equipo)
        {
            _context.equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.idequipo }, equipo);
        }

        /*
         * DELETE: "api/DeleteEquipo/idEquipo"
         * Elimina de la base de datos el equipo medico con el idequipo indicado
         * No necesario por especificacion!
         */
        /*[Route("api/DeleteEquipo/{idEquipo}")]
        [HttpDelete]
        public async Task<ActionResult<Equipo>> DeleteEquipo(int idEquipo)
        {
            var equipo = await _context.equipo.FindAsync(idEquipo);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.equipo.Remove(equipo);
            await _context.SaveChangesAsync();

            return equipo;
        }*/

        private bool EquipoExists(int idEquipo)
        {
            return _context.equipo.Any(e => e.idequipo == idEquipo);
        }
    }
}
