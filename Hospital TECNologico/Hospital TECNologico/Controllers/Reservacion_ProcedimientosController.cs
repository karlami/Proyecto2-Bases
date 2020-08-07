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
     * Controlador de Reservacion_Procedimiento
     * Recibe las solicitudes para Ingresar, Mostrar, estos de la base de datos.
     *//*
    [ApiController]
    public class Reservacion_ProcedimientosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public Reservacion_ProcedimientosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Reservacion_Procedimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion_Procedimiento>>> Getreservacion_procedimiento()
        {
            return await _context.reservacion_procedimiento.ToListAsync();
        }

        // GET: api/Reservacion_Procedimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion_Procedimiento>> GetReservacion_Procedimiento(int id)
        {
            var reservacion_Procedimiento = await _context.reservacion_procedimiento.FindAsync(id);

            if (reservacion_Procedimiento == null)
            {
                return NotFound();
            }

            return reservacion_Procedimiento;
        }

        // PUT: api/Reservacion_Procedimientos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacion_Procedimiento(int id, Reservacion_Procedimiento reservacion_Procedimiento)
        {
            if (id != reservacion_Procedimiento.idreservacion)
            {
                return BadRequest();
            }

            _context.Entry(reservacion_Procedimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reservacion_ProcedimientoExists(id))
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

        // POST: api/Reservacion_Procedimientos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservacion_Procedimiento>> PostReservacion_Procedimiento(Reservacion_Procedimiento reservacion_Procedimiento)
        {
            _context.reservacion_procedimiento.Add(reservacion_Procedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservacion_Procedimiento", new { id = reservacion_Procedimiento.idreservacion }, reservacion_Procedimiento);
        }

        // DELETE: api/Reservacion_Procedimientos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservacion_Procedimiento>> DeleteReservacion_Procedimiento(int id)
        {
            var reservacion_Procedimiento = await _context.reservacion_procedimiento.FindAsync(id);
            if (reservacion_Procedimiento == null)
            {
                return NotFound();
            }

            _context.reservacion_procedimiento.Remove(reservacion_Procedimiento);
            await _context.SaveChangesAsync();

            return reservacion_Procedimiento;
        }

        private bool Reservacion_ProcedimientoExists(int id)
        {
            return _context.reservacion_procedimiento.Any(e => e.idreservacion == id);
        }
    }*/
}
