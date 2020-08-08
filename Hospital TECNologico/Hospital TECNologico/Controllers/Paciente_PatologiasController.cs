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
     * Controlador de Paciente_Patologia
     * Recibe las solicitudes para Ingresar y Mostrar estos de la base de datos.
     */
    [ApiController]
    public class Paciente_PatologiasController : ControllerBase
    {
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de Paciente_PatologiasController
         */
        public Paciente_PatologiasController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetPacientes_Patologias"
         * Obtiene todos los pacientes_patologias de todos los pacientes en la base de datos
         */
        [Route("api/GetPacientes_Patologias")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente_Patologia>>> Getpaciente_patologia()
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes_patologiaS
            string query =
                "SELECT "
                + "idpaciente_patologia, " + "idpaciente, " + "patologia, " + "idpatologia, " + "tratamiento "
                + "FROM "
                + "viewpaciente"
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente_patologia.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetPaciente_Patologias/idPaciente"
         * Obtiene todos los pacientes_patologias de UN SOLO PACIENTE con el idpaciente indicado
         */
        [Route("api/GetPaciente_Patologias/{idpaciente}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente_Patologia>>> Getpaciente_patologia(int idpaciente)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idpaciente_patologia, " + "idpaciente, " + "patologia, " + "idpatologia, " + "tratamiento "
                + "FROM "
                + "viewpaciente "
                + "WHERE "
                + "idpaciente = " + idpaciente.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente_patologia.FromSqlRaw(query).ToListAsync();
        }



        /*
         * GET: "api/GetPaciente_Patologia/idpacientepatologia"
         * Obtiene solo el paciente_patologia con el idpacientepatologia indicado
         *           //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!
         */
        [Route("api/GetPaciente_Patologia/{idpacientepatologia}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vPaciente_Patologia>>> GetPaciente_Patologia(int idpacientepatologia)
        {
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idpaciente_patologia, " + "idpaciente, " + "patologia, " + "idpatologia, " + "tratamiento "
                + "FROM "
                + "viewpaciente "
                + "WHERE "
                + "idpacientepatologia = " + idpacientepatologia.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente_patologia.FromSqlRaw(query).ToListAsync();
        }

        /*
         * PUT: "api/PutPaciente_Patologia"
         * Actualiza un paciente_patologia con el idpacientepatologia que se indica en el Form.
         * No necesario por especificacion!
         */
        /*[Route("api/PutPaciente_Patologia")]
        [HttpPut]
        public async Task<IActionResult> PutPaciente_Patologia([FromBody] Paciente_Patologia paciente_Patologia)
        {
            if (id != paciente_Patologia.idpaciente)
            {
                return BadRequest();
            }

            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!

            _context.Entry(paciente_Patologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Paciente_PatologiaExists(id))
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
         * POST: "api/PostPaciente_Patologia"
         * Agregar un paciente_patologia nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostPaciente_Patologia")]
        [HttpPost]
        public async Task<ActionResult<Paciente_Patologia>> PostPaciente_Patologia([FromBody] Paciente_Patologia paciente_Patologia)
        {
            _context.paciente_patologia.Add(paciente_Patologia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente_Patologia", new { id = paciente_Patologia.idpaciente }, paciente_Patologia);
        }

        /*
         * DELETE: "api/DeletePaciente_Patologia/idpacientepatologia"
         * Elimina de la base de datos el paciente_patologia con el idpacientepatologia indicado
         * No necesario por especificacion!
         */
        /*[Route("api/DeletePaciente_Patologia/{idpacientepatologia}")]
        [HttpDelete]
        public async Task<ActionResult<Paciente_Patologia>> DeletePaciente_Patologia(int idpacientepatologia)
        {
            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!

            var paciente_Patologia = await _context.paciente_patologia.FindAsync(idpacientepatologia);
            if (paciente_Patologia == null)
            {
                return NotFound();
            }

            _context.paciente_patologia.Remove(paciente_Patologia);
            await _context.SaveChangesAsync();

            return paciente_Patologia;
        }*/

        private bool Paciente_PatologiaExists(int idpacientepatologia)
        {
            return _context.paciente_patologia.Any(e => e.idpaciente == idpacientepatologia);
        }
    }
}
