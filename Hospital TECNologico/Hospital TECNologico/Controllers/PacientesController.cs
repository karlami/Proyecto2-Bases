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
    public class PacientesController : ControllerBase
    {
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de PacientesController
         */
        public PacientesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetPacientes"
         * Obtiene todos los pacientes en la base de datos
         */
        [Route("api/GetPacientes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> Getpaciente()
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idpaciente, " + "cedula, " + "nombrepaciente, " + "telefono, " + "direccion, " + "fechanacimiento, " + "contrasena, " + "patologia, " + "tratamiento "
                + "FROM "
                + "viewPaciente"
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetPacienteC/cedula"
         * Obtiene solo el paciente con la cedula indicado
         */
        [Route("api/GetPacienteC/{cedula}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> GetPacienteC(int cedula)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idpaciente, " + "cedula, " + "nombrepaciente, " + "telefono, " + "direccion, " + "fechanacimiento, " + "contrasena, " + "patologia, " + "tratamiento "
                + "FROM "
                + "viewPaciente " 
                + "WHERE "
                + "cedula = " + cedula.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetPaciente/idPaciente"
         * Obtiene solo el paciente con el idpaciente indicado
         */
        [Route("api/GetPaciente/{idpaciente}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente>>> GetPaciente(int idpaciente)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idpaciente, " + "cedula, " + "nombrepaciente, " + "telefono, " + "direccion, " + "fechanacimiento, " + "contrasena, " + "patologia, " + "tratamiento "
                + "FROM "
                + "viewPaciente "
                + "WHERE "
                + "idpaciente = " + idpaciente.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
        }

        /*
         * PUT: "api/PutPaciente"
         * Actualiza un paciente con el idpaciente que se indica en el Form.
         * No necesario por especificacion!
         */
        /*[Route("api/PutPaciente")]
        [HttpPut]
        public async Task<IActionResult> PutPaciente([FromBody] Paciente paciente)
        {
            if (id != paciente.cedula)
            {
                return BadRequest();
            }

            //PUT EN UPDATE DE STORED PROCEDURE DE PACIENTE

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
        }*/

        /*
         * POST: "api/PostPaciente"
         * Agregar un paciente nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostPaciente")]
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente([FromBody] Paciente paciente)
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

            await _context.Database.ExecuteSqlRawAsync(query);


            return paciente; //CreatedAtAction("GetPaciente", new { id = paciente.cedula }, paciente);
        }

        /*
         * DELETE: "api/DeletePaciente/idPaciente"
         * Elimina de la base de datos el paciente con el idpaciente indicado
         * No necesario por especificacion!
         */
        /*[Route("api/DeletePaciente/{idpaciente}")]
        [HttpDelete]
        public async Task<ActionResult<Paciente>> DeletePaciente(int idpaciente)
        {
            //DELETE EN DELETE DE STORED PROCEDURE DE PACIENTE

            var paciente = await _context.paciente.FindAsync(idpaciente);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }*/
        
        private bool PacienteExists(int idpaciente)
        {
            return _context.paciente.Any(e => e.cedula == idpaciente);
        }
    }
}
