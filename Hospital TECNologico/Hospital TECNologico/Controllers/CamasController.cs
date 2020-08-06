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
        [Route("api/GetCamas")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cama>>> Getcama()
        {
            //GET DE UN VIEW ESPECIFICO DE CAMAS
            //TODOS TODOS LOS (CAMAS X EQUIPOS X SALONES) 

            return await _context.cama.ToListAsync();
        }

        /*
         * GET: "api/GetCama/numeroCama"
         * Obtiene solo la cama con el numerocama indicado
         */
        [Route("api/GetCama/{numerocama}")]
        [HttpGet]
        public async Task<ActionResult<Cama>> GetCama(int numerocama)
        {
            //GET DE UN VIEW ESPECIFICO DE CAMAS
            //UNA UNICA (CAMAS X EQUIPOS X SALONES)

            var cama = await _context.cama.FindAsync(numerocama);

            if (cama == null)
            {
                return NotFound();
            }

            return cama;
        }

        /*
         * PUT: "api/PutCama"
         * Actualiza una cama con el numerocama que se indica en el Form.
         */
        [Route("api/PutCama")]
        [HttpPut]
        public async Task<IActionResult> PutCama([FromBody] Cama cama)
        {
            /*if (id != cama.numerocama)
            {
                return BadRequest();
            }*/

            //PUT EN UPDATE DE STORED PROCEDURE DE CAMA

            _context.Entry(cama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamaExists(cama.numerocama))
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
         * POST: "api/PostCama"
         * Agregar una cama nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostCama")]
        [HttpPost]
        public async Task<ActionResult<Cama>> PostCama([FromBody] Cama cama)
        {
            /*_context.cama.Add(cama);
            await _context.SaveChangesAsync();*/

            string query = "CALL agregarPaciente(";             //CAMBIAR QUERY POR EL STORED PROCEDURE DE CAMA
            /*+ paciente.cedula.ToString() + ", '"
            + paciente.nombre.ToString() + "', '"
            + paciente.primerapellido.ToString() + "', '"
            + paciente.segundoapellido.ToString() + "', "
            + paciente.telefono.ToString() + ", '"
            + paciente.fechanacimiento.ToString() + "', '"
            + paciente.contrasena.ToString() + "', "
            + paciente.iddireccion.ToString() + "); ";*/

            Console.WriteLine(query);

            return CreatedAtAction("GetCama", new { id = cama.numerocama }, cama);
        }

        /*
         * DELETE: "api/DeleteCama/numeroCama"
         * Elimina de la base de datos la cama con el numerocama indicado
         * No necesario por especificacion!
         */
        [Route("api/DeleteCama/{numerocama}")]
        [HttpDelete]
        public async Task<ActionResult<Cama>> DeleteCama(int numerocama)
        {
            //DELETE EN DELETE DE STORED PROCEDURE DE EMPLEADO

            var cama = await _context.cama.FindAsync(numerocama);
            if (cama == null)
            {
                return NotFound();
            }

            _context.cama.Remove(cama);
            await _context.SaveChangesAsync();

            return cama;
        }

        private bool CamaExists(int numerocama)
        {
            return _context.cama.Any(e => e.numerocama == numerocama);
        }
    }
}
