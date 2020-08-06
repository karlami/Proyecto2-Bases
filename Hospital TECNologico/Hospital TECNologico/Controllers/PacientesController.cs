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
    public class PacientesController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public PacientesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [Route("api/GetPacientes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> Getpaciente()
        {
            return await _context.paciente.ToListAsync();
        }

        // GET: api/Pacientes/5
        [Route("api/GetPaciente/{id}")]
        [HttpGet]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _context.paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/Pacientes/5
        [Route("api/PutPaciente")]
        [HttpPut]
        public async Task<IActionResult> PutPaciente([FromForm] Paciente paciente)
        {
            /*if (id != paciente.cedula)
            {
                return BadRequest();
            }*/

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(paciente.idpaciente))
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

        // POST: api/Pacientes
        [Route("api/PostPaciente")]
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente([FromForm] Paciente paciente)
        {
            /*_context.paciente.Add(paciente);
            await _context.SaveChangesAsync();*/

            string query = "CALL agregarPaciente("
                + paciente.cedula.ToString() + ", '"
                + paciente.nombre.ToString() + "', '"
                + paciente.primerapellido.ToString() + "', '"
                + paciente.segundoapellido.ToString() + "', "
                + paciente.telefono.ToString() + ", '"
                + paciente.fechanacimiento.ToString() + "', '"
                + paciente.contrasena.ToString() + "', "
                + paciente.iddireccion.ToString() + "); ";

            Console.WriteLine(query);

            //var nPaciente = await _context.paciente.Update();
            //var mpaciente = await _context.paciente.FindAsync(id);

            await _context.Database.ExecuteSqlRawAsync(query);


            return paciente; //CreatedAtAction("GetPaciente", new { id = paciente.cedula }, paciente);
        }

        // DELETE: api/Pacientes/5
        [Route("api/DeletePaciente/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Paciente>> DeletePaciente(int id)
        {
            var paciente = await _context.paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        private bool PacienteExists(int id)
        {
            return _context.paciente.Any(e => e.cedula == id);
        }
    }
}
