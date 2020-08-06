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
     * Controlador de Historial Clinico
     * Recibe las solicitudes para Ingresar, Mostrar y Modificar estos de la base de datos.
     */
    [ApiController]
    public class Historiales_ClinicosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public Historiales_ClinicosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetHistoriales_Clinicos"
         * Obtiene todos los historiales clinicos de todos los pacientes en la base de datos
         */
        [Route("api/GetHistoriales_Clinicos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial_Clinico>>> Gethistorial_clinico()
        {
            //GET DE UN VIEW ESPECIFICO DE HISTORIAL_CLINICO
            //TODOS TODOS LOS (HISTORIALES CLINICOS X PROCEDIMIENTOS X PACIENTES)
            return await _context.historial_clinico.ToListAsync();
        }

        /*
         * GET: "api/GetHistoriales_Clinicos/idPaciente"
         * Obtiene todos los historiales clinicos de UN SOLO PACIENTE con el idpaciente indicado
         */
        [Route("api/GetHistoriales_Clinicos/{idpaciente}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial_Clinico>>> Gethistorial_clinico(int idpaciente)
        {
            //GET DE UN VIEW ESPECIFICO DE HISTORIAL_CLINICO
            //TODOS LOS (HISTORIALES CLINICOS X PROCEDIMIENTOS X PACIENTES) DE UN PACIENTE ESPECIFICO
            return await _context.historial_clinico.ToListAsync();
        }

        /*
         * GET: "api/GetHistorial_Clinico/idHistorial"
         * Obtiene solo el historial clinico con el idhistorial indicado
         */
        [Route("api/GetHistorial_Clinico/{idhistorial}")]
        [HttpGet]
        public async Task<ActionResult<Historial_Clinico>> GetHistorial_Clinico(int idhistorial)
        {
            //GET DE UN VIEW ESPECIFICO DE HISTORIAL_CLINICO
            //UN UNICO (HISTORIALES CLINICOS X PROCEDIMIENTOS X PACIENTES)

            var historial_Clinico = await _context.historial_clinico.FindAsync(idhistorial);

            if (historial_Clinico == null)
            {
                return NotFound();
            }

            return historial_Clinico;
        }

        /*
         * PUT: "api/PutHistorial_Clinico"
         * Actualiza un historial clinico con el idhistorial que se indica en el Form.
         */
        [Route("api/PutHistorial_Clinico")]
        [HttpPut]
        public async Task<IActionResult> PutHistorial_Clinico([FromBody] Historial_Clinico historial_clinico)
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

        /*
         * POST: "api/PostHistorial_Clinico"
         * Agregar un historial clinico nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostHistorial_Clinico")]
        [HttpPost]
        public async Task<ActionResult<Historial_Clinico>> PostHistorial_Clinico([FromBody] Historial_Clinico historial_clinico)
        {
            _context.historial_clinico.Add(historial_clinico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorial_Clinico", new { id = historial_clinico.idhistorial }, historial_clinico);
        }

        /*
         * DELETE: "api/DeleteHistorial_Clinico/idHistorial"
         * Elimina de la base de datos el historial clinico con el idhistorial indicado
         * No necesario por especificacion!
         */
        [Route("api/DeleteHistorial_Clinico/{idhistorial}")]
        [HttpDelete]
        public async Task<ActionResult<Historial_Clinico>> DeleteHistorial_Clinico(int idhistorial)
        {
            var historial_Clinico = await _context.historial_clinico.FindAsync(idhistorial);
            if (historial_Clinico == null)
            {
                return NotFound();
            }

            _context.historial_clinico.Remove(historial_Clinico);
            await _context.SaveChangesAsync();

            return historial_Clinico;
        }

        private bool Historial_ClinicoExists(int idhistorial)
        {
            return _context.historial_clinico.Any(e => e.idhistorial == idhistorial);
        }
    }
}
