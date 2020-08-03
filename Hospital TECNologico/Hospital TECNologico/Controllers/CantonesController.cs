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
    [Route("api/[controller]")]
    [ApiController]
    public class CantonesController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public CantonesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Cantons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canton>>> Getcanton()
        {
            Console.WriteLine("canton");
            return await _context.canton.ToListAsync();
        }

        // GET: api/Cantons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canton>> GetCanton(int id)
        {
            var canton = await _context.canton.FindAsync(id);

            if (canton == null)
            {
                return NotFound();
            }

            return canton;
        }

        // PUT: api/Cantons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanton(int id, Canton canton)
        {
            if (id != canton.idcanton)
            {
                return BadRequest();
            }

            _context.Entry(canton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(id))
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

        // POST: api/Cantons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Canton>> PostCanton([FromBody] Canton canton)
        {
            Console.WriteLine(canton.ToString());

            _context.canton.Add(canton);
            await _context.SaveChangesAsync();

            //Console.WriteLine(canton.idcanton);

            return CreatedAtAction("GetCanton", new { id = canton.idcanton }, canton);
        }

        // DELETE: api/Cantons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canton>> DeleteCanton(int id)
        {
            var canton = await _context.canton.FindAsync(id);
            if (canton == null)
            {
                return NotFound();
            }

            _context.canton.Remove(canton);
            await _context.SaveChangesAsync();

            return canton;
        }

        private bool CantonExists(int id)
        {
            return _context.canton.Any(e => e.idcanton == id);
        }
    }
}
