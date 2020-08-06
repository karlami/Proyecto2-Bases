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
     * Controlador de Paciente_Patologia
     * Recibe las solicitudes para Ingresar y Mostrar estos de la base de datos.
     */
    [ApiController]
    public class Paciente_PatologiasController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

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
        public async Task<ActionResult<IEnumerable<Paciente_Patologia>>> Getpaciente_patologia()
        {
            //GET DE UN VIEW ESPECIFICO DE PACIENTES_PATOLOGIAS
            //TODOS TODOS LOS (PACIENTES_PATOLOGIAS X PATOLOGIAS)

            //FUNCIONA CON LA TABLA ESPECIFICA DE PACIENTES_PATOLOGIAS -> POR MIENTRAS
            return await _context.paciente_patologia.ToListAsync();
        }

        /*
         * GET: "api/GetPaciente_Patologias/idPaciente"
         * Obtiene todos los pacientes_patologias de UN SOLO PACIENTE con el idpaciente indicado
         */
        [Route("api/GetPaciente_Patologias/{idpaciente}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente_Patologia>>> Getpaciente_patologia(int idpaciente)
        {
            //GET DE UN VIEW ESPECIFICO DE PACIENTES_PATOLOGIAS
            //TODOS TODOS LOS (PACIENTES_PATOLOGIAS X PATOLOGIAS)
            return await _context.paciente_patologia.ToListAsync();
        }



        /*
         * GET: "api/GetPaciente_Patologia/idpacientepatologia"
         * Obtiene solo el paciente_patologia con el idpacientepatologia indicado
         *           //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!
         */
        [Route("api/GetPaciente_Patologia/{idpacientepatologia}")]
        [HttpGet]
        public async Task<ActionResult<Paciente_Patologia>> GetPaciente_Patologia(int idpacientepatologia)
        {
            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!
            //GET DE UN VIEW ESPECIFICO DE PACIENTES_PATOLOGIAS
            //UN UNICO (PACIENTES_PATOLOGIAS X PATOLOGIAS)

            var paciente_Patologia = await _context.paciente_patologia.FindAsync(idpacientepatologia);

            if (paciente_Patologia == null)
            {
                return NotFound();
            }

            return paciente_Patologia;
        }

        /*
         * PUT: "api/PutPaciente_Patologia"
         * Actualiza un paciente_patologia con el idpacientepatologia que se indica en el Form.
         * No necesario por especificacion!
         *            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!
         */
        [Route("api/PutPaciente_Patologia")]
        [HttpPut]
        public async Task<IActionResult> PutPaciente_Patologia([FromForm] Paciente_Patologia paciente_Patologia)
        {
            /*if (id != paciente_Patologia.idpaciente)
            {
                return BadRequest();
            }*/

            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!

            _context.Entry(paciente_Patologia).State = EntityState.Modified;

            /*try
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
            }*/

            return NoContent();
        }

        /*
         * POST: "api/PostPaciente_Patologia"
         * Agregar un paciente_patologia nuevo a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostPaciente_Patologia")]
        [HttpPost]
        public async Task<ActionResult<Paciente_Patologia>> PostPaciente_Patologia([FromForm] Paciente_Patologia paciente_Patologia)
        {
            _context.paciente_patologia.Add(paciente_Patologia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente_Patologia", new { id = paciente_Patologia.idpaciente }, paciente_Patologia);
        }

        /*
         * DELETE: "api/DeletePaciente_Patologia/idpacientepatologia"
         * Elimina de la base de datos el paciente_patologia con el idpacientepatologia indicado
         * No necesario por especificacion!
         *            //SOLO SI SE AGREGA IDPACIENTE_PATOLOGIA!!!
         */
        [Route("api/DeletePaciente_Patologia/{idpacientepatologia}")]
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
        }

        private bool Paciente_PatologiaExists(int idpacientepatologia)
        {
            return _context.paciente_patologia.Any(e => e.idpaciente == idpacientepatologia);
        }
    }
}
