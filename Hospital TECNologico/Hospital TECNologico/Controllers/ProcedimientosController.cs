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
     * Controlador de Procedimiento
     * Recibe las solicitudes para Ingresar, Mostrar y Modificar estos de la base de datos.
     */
    [ApiController]
    public class ProcedimientosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public ProcedimientosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetProcedimientos"
         * Obtiene todos los procedimientos en la base de datos
         */
        [Route("api/GetProcedimientos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedimiento>>> Getprocedimiento()
        {
            return await _context.procedimiento.ToListAsync();
        }

        /*
         * GET: "api/GetProcedimiento/idProcedimiento"
         * Obtiene solo el procedimiento con el idprocedimiento indicado
         */
        [Route("api/GetProcedimiento/{idprocedimiento}")]
        [HttpGet]
        public async Task<ActionResult<Procedimiento>> GetProcedimiento(int idprocedimiento)
        {
            var procedimiento = await _context.procedimiento.FindAsync(idprocedimiento);

            if (procedimiento == null)
            {
                return NotFound();
            }

            return procedimiento;
        }

        /*
         * PUT: "api/PutProcedimiento"
         * Actualiza un procedimiento con el idprocedimiento que se indica en el Form.
         */
        [Route("api/PutProcedimiento")]
        [HttpPut]
        public async Task<IActionResult> PutProcedimiento([FromBody] Procedimiento procedimiento)
        {
            /*if (id != procedimiento.idprocedimiento)
            {
                return BadRequest();
            }*/

            _context.Entry(procedimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimientoExists(procedimiento.idprocedimiento))
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
         * POST: "api/PostProcedimiento"
         * Agregar un procedimiento nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostProcedimiento")]
        [HttpPost]
        public async Task<ActionResult<Procedimiento>> PostProcedimiento([FromBody] Procedimiento procedimiento)
        {
            _context.procedimiento.Add(procedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedimiento", new { id = procedimiento.idprocedimiento }, procedimiento);
        }

        /*
         * DELETE: "api/DeleteProcedimiento/idProcedimiento"
         * Elimina de la base de datos el procedimiento con el idprocedimiento indicado
         * No necesario por especificacion!
         */
        [Route("api/DeleteProcedimiento/{idprocedimiento}")]
        [HttpDelete]
        public async Task<ActionResult<Procedimiento>> DeleteProcedimiento(int idprocedimiento)
        {
            var procedimiento = await _context.procedimiento.FindAsync(idprocedimiento);
            if (procedimiento == null)
            {
                return NotFound();
            }

            _context.procedimiento.Remove(procedimiento);
            await _context.SaveChangesAsync();

            return procedimiento;
        }

        private bool ProcedimientoExists(int idprocedimiento)
        {
            return _context.procedimiento.Any(e => e.idprocedimiento == idprocedimiento);
        }
    }
}
