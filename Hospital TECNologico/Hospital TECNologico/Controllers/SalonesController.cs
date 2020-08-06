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
     * Controlador de Salon
     * Recibe las solicitudes para Ingresar, Mostrar, Modificar y Eliminar estos de la base de datos.
     */
    [ApiController]
    public class SalonesController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public SalonesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetSalones"
         * Obtiene todos los salones en la base de datos
         */
        [Route("api/GetSalones")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalon()
        {
            return await _context.salon.ToListAsync();
        }

        /*
         * GET: "api/GetSalon/idSalon"
         * Obtiene solo el salon con el idsalon indicado
         */
        [Route("api/GetSalon/{idSalon}")]
        [HttpGet]
        public async Task<ActionResult<Salon>> GetSalon(int idSalon)
        {
            var salon = await _context.salon.FindAsync(idSalon);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        /*
         * PUT: "api/PutSalon"
         * Actualiza un salon con el idsalon que se indica en el Form.
         */
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

        /*
         * POST: "api/PostSalon"
         * Agregar un salon nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostSalon")]
        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon([FromForm] Salon salon)
        {
            _context.salon.Add(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.numerosalon }, salon);
        }

        /*
         * DELETE: "api/DeleteSalon/{idsalon}"
         * Elimina de la base de datos el salon con el idsalon indicado
         */
        [Route("api/DeleteSalon/{idSalon}")]
        [HttpDelete]
        public async Task<ActionResult<Salon>> DeleteSalon(int idSalon)
        {
            var salon = await _context.salon.FindAsync(idSalon);
            if (salon == null)
            {
                return NotFound();
            }

            _context.salon.Remove(salon);
            await _context.SaveChangesAsync();

            return salon;
        }

        private bool SalonExists(int idSalon)
        {
            return _context.salon.Any(e => e.numerosalon == idSalon);
        }
    }
}
