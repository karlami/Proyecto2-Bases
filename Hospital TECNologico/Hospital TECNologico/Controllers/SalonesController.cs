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
    public class SalonesController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public SalonesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Salones
        [Route("api/GetSalones")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalon()
        {
            return await _context.salon.ToListAsync();
        }

        // GET: api/Salones/5
        [Route("api/GetSalon/{id}")]
        [HttpGet]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _context.salon.FindAsync(id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        // PUT: api/Salones/5
        [Route("api/PutSalon")]
        [HttpPut]
        public async Task<IActionResult> PutSalon([FromForm] Salon salon)
        {
            /*if (id != salon.numerosalon)
            {
                return BadRequest();
            }*/

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(salon.numerosalon))
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

        // POST: api/Salones
        [Route("api/PostSalon")]
        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon([FromForm] Salon salon)
        {
            _context.salon.Add(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.numerosalon }, salon);
        }

        // DELETE: api/Salones/5
        [Route("api/DeleteSalon/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Salon>> DeleteSalon(int id)
        {
            var salon = await _context.salon.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.salon.Remove(salon);
            await _context.SaveChangesAsync();

            return salon;
        }

        private bool SalonExists(int id)
        {
            return _context.salon.Any(e => e.numerosalon == id);
        }
    }
}
