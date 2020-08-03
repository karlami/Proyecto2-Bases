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
    //[Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<Procedimiento>>> GetProcedimiento()
        {
            return await _context.Procedimiento.ToListAsync();
        }

        // GET: api/Procedimientos/5
        [Route("api/GetProcedimiento/{id}")]
        [HttpGet] //("{id}")]
        public async Task<ActionResult<Procedimiento>> GetProcedimiento(int id)
        {
            var procedimiento = await _context.Procedimiento.FindAsync(id);

            if (procedimiento == null)
            {
                return NotFound();
            }

            return procedimiento;
        }

        // PUT: api/Procedimientos/5
        [Route("api/PutEquipo")]
        [HttpPut] //("{id}")]
        public async Task<IActionResult> PutProcedimiento(/*int id,*/ [FromForm] Procedimiento procedimiento)
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
        [Route("api/PostEquipo")]
        [HttpPost]
        public async Task<ActionResult<Procedimiento>> PostProcedimiento([FromForm] Procedimiento procedimiento)
        {
            _context.Procedimiento.Add(procedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedimiento", new { id = procedimiento.idprocedimiento }, procedimiento);
        }

        // DELETE: api/Procedimientos/5
        [Route("api/DeleteProcedimiento/{id}")]
        [HttpDelete] //("{id}")]
        public async Task<ActionResult<Procedimiento>> DeleteProcedimiento(int id)
        {
            var procedimiento = await _context.Procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            _context.Procedimiento.Remove(procedimiento);
            await _context.SaveChangesAsync();

            return procedimiento;
        }

        private bool ProcedimientoExists(int id)
        {
            return _context.Procedimiento.Any(e => e.idprocedimiento == id);
        }
    }
}
