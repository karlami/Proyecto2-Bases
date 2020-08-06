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
     * Controlador de Cama
     * Recibe las solicitudes para Ingresar, Mostrar y Modificar estos de la base de datos.
     */
    [Route("api/{controller}")]
    [ApiController]
    public class CamasController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public CamasController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetCamas"
         * Obtiene todas las camas en la base de datos
         */
        //[Route("api/GetCamas")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cama>>> Getcama()
        {
            return await _context.cama.ToListAsync();
        }

        // GET: api/Camas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cama>> GetCama(int id)
        {
            var cama = await _context.cama.FindAsync(id);

            if (cama == null)
            {
                return NotFound();
            }

            return cama;
        }

        // PUT: api/Camas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCama(int id, Cama cama)
        {
            if (id != cama.numerocama)
            {
                return BadRequest();
            }

            _context.Entry(cama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamaExists(id))
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

        // POST: api/Camas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cama>> PostCama(Cama cama)
        {
            /*_context.cama.Add(cama);
            await _context.SaveChangesAsync();*/

            //NECESITA UN STORED PROCEDURE

            return CreatedAtAction("GetCama", new { id = cama.numerocama }, cama);
        }

        // DELETE: api/Camas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cama>> DeleteCama(int id)
        {
            var cama = await _context.cama.FindAsync(id);
            if (cama == null)
            {
                return NotFound();
            }

            _context.cama.Remove(cama);
            await _context.SaveChangesAsync();

            return cama;
        }

        private bool CamaExists(int id)
        {
            return _context.cama.Any(e => e.numerocama == id);
        }
    }
}
