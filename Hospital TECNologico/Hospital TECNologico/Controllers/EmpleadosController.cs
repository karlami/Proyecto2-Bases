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
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de EmpleadosController
         */
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
        public async Task<ActionResult<Empleado>> /*Task<IActionResult>*/ PutEmpleado([FromBody] Empleado empleado)
        {
            //Query para llamar al Stored Procedure de Empleado y Actualizar las tablas que necesita
            string query = "CALL modificarPersonal("
                + empleado.idempleado.ToString() + ", "
                + empleado.cedula.ToString() + ", '"
                + empleado.nombre.ToString() + "', '"
                + empleado.primerapellido.ToString() + "', '"
                + empleado.segundoapellido.ToString() + "', "
                + empleado.telefono.ToString() + ", '"
                + empleado.fechanacimiento.ToString() + "', '"
                + empleado.contrasena.ToString() + "', "
                + empleado.iddireccion.ToString() + ", '"
                + empleado.fechaingreso.ToString() + "', "
                + empleado.idpuesto.ToString() + ", "
                + "'Update'" + "); ";

            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            return empleado;
        }

        /*
         * POST: "api/PostEmpleado"
         * Agregar un empleado nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostEmpleado")]
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody] Empleado empleado)
        {
            /*_context.empleado.Add(empleado);
            await _context.SaveChangesAsync();*/

            string query = "CALL modificarPersonal("
                + empleado.idempleado.ToString() + ", "
                + empleado.cedula.ToString() + ", '"
                + empleado.nombre.ToString() + "', '"
                + empleado.primerapellido.ToString() + "', '"
                + empleado.segundoapellido.ToString() + "', "
                + empleado.telefono.ToString() + ", '"
                + empleado.fechanacimiento.ToString() + "', '"
                + empleado.contrasena.ToString() + "', "
                + empleado.iddireccion.ToString() + ", '"
                + empleado.fechaingreso.ToString() + "', "
                + empleado.idpuesto.ToString() + ", "
                + "'Insert'" + "); ";

            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            return empleado;

            //return CreatedAtAction("GetEmpleado", new { id = empleado.idempleado }, empleado);
        }

        /*
         * DELETE: "api/DeleteEmpleado/idEmpleado"
         * Elimina de la base de datos el empleado con el idempleado indicado
         */
        [Route("api/DeleteEmpleado/{idempleado}")]
        [HttpDelete]
        public async Task<ActionResult/*<Empleado>*/> DeleteEmpleado(int idempleado)
        {
            //DELETE EN DELETE DE STORED PROCEDURE DE EMPLEADO

            /*var empleado = await _context.empleado.FindAsync(idempleado);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;*/

            string query = "CALL modificarPersonal("
                + idempleado.ToString() + ", "
                + "0" + ", '"
                + "empleado.nombre.ToString()" + "', '"
                + "empleado.primerapellido.ToString()" + "', '"
                + "empleado.segundoapellido.ToString()" + "', "
                + "0" + ", '"
                + "1-1-1" + "', '"
                + "empleado.contrasena.ToString()" + "', "
                + "0" + ", '"
                + "1-1-1" + "', "
                + "0" + ", "
                + "'Delete'" + "); ";

            Console.WriteLine(query);

            await _context.Database.ExecuteSqlRawAsync(query);

            //return empleado;

            return Ok("Se ha borrado el empleado con idempleado: " + idempleado.ToString());
        }

        private bool EmpleadoExists(int idempleado)
        {
            return _context.empleado.Any(e => e.idempleado == idempleado);
        }
    }
}
