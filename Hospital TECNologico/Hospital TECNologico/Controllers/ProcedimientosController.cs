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
    public class ProcedimientosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public ProcedimientosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Procedimientos
        [Route("api/GetProcedimientos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedimiento>>> Getprocedimiento()
        {
            return await _context.procedimiento.ToListAsync();
        }

        // GET: api/Procedimientos/5
        [Route("api/GetProcedimiento/{id}")]
        [HttpGet]
        public async Task<ActionResult<Procedimiento>> GetProcedimiento(int id)
        {
            var procedimiento = await _context.procedimiento.FindAsync(id);

            if (procedimiento == null)
            {
                return NotFound();
            }

            return procedimiento;
        }

        // PUT: api/Procedimientos/5
        [Route("api/PutProcedimiento")]
        [HttpPut]
        public async Task<IActionResult> PutProcedimiento([FromForm] Procedimiento procedimiento)
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

        // POST: api/Procedimientos
        [Route("api/PostProcedimiento")]
        [HttpPost]
        public async Task<ActionResult<Procedimiento>> PostProcedimiento([FromForm] Procedimiento procedimiento)
        {
            _context.procedimiento.Add(procedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedimiento", new { id = procedimiento.idprocedimiento }, procedimiento);
        }

        // DELETE: api/Procedimientos/5
        [Route("api/DeleteProcedimiento/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Procedimiento>> DeleteProcedimiento(int id)
        {
            var procedimiento = await _context.procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            _context.procedimiento.Remove(procedimiento);
            await _context.SaveChangesAsync();

            return procedimiento;
        }

        private bool ProcedimientoExists(int id)
        {
            return _context.procedimiento.Any(e => e.idprocedimiento == id);
        }
    }
}
