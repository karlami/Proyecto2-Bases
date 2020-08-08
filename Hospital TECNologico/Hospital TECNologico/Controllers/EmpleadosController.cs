using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_TECNologico.Data;
using Hospital_TECNologico.Models;
using Hospital_TECNologico.Models.Views;

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
        public async Task<ActionResult<IEnumerable<vEmpleado>>> Getempleado()
        {
            //Query de SELECT de viewPersonal para obtener los datos necesarios para mostrar todos los empleados
            string query =
                "SELECT "
                + "idempleado, " + "cedula, " + "nombre, " + "primerapellido, " + "segundoapellido, " + "telefono, " + "fechanacimiento, " 
                + "contrasena, " + "direccion, " + "iddireccion, " + "fechaingreso, " + "idpuesto, " + "nombrepuesto "
                + "FROM "
                + "viewPersonal " + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vempleado.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetEmpleadoC/cedula"
         * Obtiene solo el empelado con la cedula indicada
         */
        [Route("api/GetEmpleadoC/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vEmpleado>>> GetEmpleadoC(int cedula)
        {
            //Query de SELECT de viewPersonal para obtener los datos necesarios para mostrar todos los empleados
            string query =
                "SELECT "
                + "idempleado, " + "cedula, " + "nombre, " + "primerapellido, " + "segundoapellido, " + "telefono, " + "fechanacimiento, "
                + "contrasena, " + "direccion, " + "iddireccion, " + "fechaingreso, " + "idpuesto, " + "nombrepuesto "
                + "FROM "
                + "viewPersonal "
                + "WHERE "
                + "cedula = " + cedula.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vempleado.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetEmpleado/idEmpelado"
         * Obtiene solo el empelado con el idempelado indicado
         */
        [Route("api/GetEmpleado/{idempelado}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vEmpleado>>> GetEmpleado(int idempelado)
        {
            //Query de SELECT de viewPersonal para obtener los datos necesarios para mostrar todos los empleados
            string query =
                "SELECT "
                + "idempleado, " + "cedula, " + "nombre, " + "primerapellido, " + "segundoapellido, " + "telefono, " + "fechanacimiento, "
                + "contrasena, " + "direccion, " + "iddireccion, " + "fechaingreso, " + "idpuesto, " + "nombrepuesto "
                + "FROM "
                + "viewPersonal "
                + "WHERE "
                + "idempleado = " + idempelado.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vempleado.FromSqlRaw(query).ToListAsync();
        }

        /*
         * PUT: "api/PutEmpleado"
         * Actualiza un empleado con el idempleado que se indica en el Form.
         */
        [Route("api/PutEmpleado")]
        [HttpPut]
        public async Task<ActionResult<Empleado>> PutEmpleado([FromBody] Empleado empleado)
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

            //Corre el Query
            await _context.Database.ExecuteSqlRawAsync(query);

            return Ok("Se ha borrado el empleado con idempleado: " + idempleado.ToString());
        }

        private bool EmpleadoExists(int idempleado)
        {
            return _context.empleado.Any(e => e.idempleado == idempleado);
        }
    }
}
