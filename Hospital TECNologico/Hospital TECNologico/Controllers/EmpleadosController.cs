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
     * Controlador de Paciente
     * Recibe las solicitudes para Ingresary y Mostrar estos de la base de datos.
     */
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public EmpleadosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetEmpleados"
         * Obtiene todos los empleados en la base de datos
         */
        [Route("api/GetEmpleados")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Getempleado()
        {
            //GET DE UN VIEW ESPECIFICO DE EMPLEADOS
            //TODOS TODOS LOS (EMPLEADOS X PERSONAS) 

            return await _context.empleado.ToListAsync();
        }

        /*
         * GET: "api/GetEmpleado/idEmpelado"
         * Obtiene solo el empelado con el idempelado indicado
         */
        [Route("api/GetEmpleado/{idempelado}")]
        [HttpGet]
        public async Task<ActionResult<Empleado>> GetEmpleado(int idempelado)
        {
            //GET DE UN VIEW ESPECIFICO DE EMPELADOS
            //UN UNICO (EMPLEADOS X PERSONAS)

            var empleado = await _context.empleado.FindAsync(idempelado);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        /*
         * PUT: "api/PutEmpleado"
         * Actualiza un empleado con el idempleado que se indica en el Form.
         */
        [Route("api/PutEmpleado")]
        [HttpPut]
        public async Task<IActionResult> PutEmpleado([FromForm] Empleado empleado)
        {
            /*if (id != empleado.idempleado)
            {
                return BadRequest();
            }*/

            //PUT EN UPDATE DE STORED PROCEDURE DE EMPLEADO

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(empleado.idempleado))
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
         * POST: "api/PostEmpleado"
         * Agregar un empleado nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostEmpleado")]
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            /*_context.empleado.Add(empleado);
            await _context.SaveChangesAsync();*/

            string query = "CALL agregarPaciente(";             //CAMBIAR QUERY POR EL STORED PROCEDURE DE EMPLEADO
                /*+ paciente.cedula.ToString() + ", '"
                + paciente.nombre.ToString() + "', '"
                + paciente.primerapellido.ToString() + "', '"
                + paciente.segundoapellido.ToString() + "', "
                + paciente.telefono.ToString() + ", '"
                + paciente.fechanacimiento.ToString() + "', '"
                + paciente.contrasena.ToString() + "', "
                + paciente.iddireccion.ToString() + "); ";*/

            Console.WriteLine(query);

            return CreatedAtAction("GetEmpleado", new { id = empleado.idempleado }, empleado);
        }

        /*
         * DELETE: "api/DeleteEmpleado/idEmpleado"
         * Elimina de la base de datos el empleado con el idempleado indicado
         */
        [Route("api/DeleteEmpleado/{idempleado}")]
        [HttpDelete]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(int id)
        {
            //DELETE EN DELETE DE STORED PROCEDURE DE EMPLEADO

            var empleado = await _context.empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(int id)
        {
            return _context.empleado.Any(e => e.idempleado == id);
        }
    }
}
