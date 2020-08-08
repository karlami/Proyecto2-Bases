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
     * Controlador de Reservacion_Procedimientos
     * Recibe las solicitudes para Ingresar y Mostrar estos de la base de datos.
     */
    [ApiController]
    public class Reservacion_ProcedimientosController : ControllerBase
    {
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de Reservacion_Procedimientos
         */
        public Reservacion_ProcedimientosController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetReservaciones_Procedimientos"
         * Obtiene todas las reservaciones_procedimientos de todos los pacientes en la base de datos
         * NOT ESSENTIAL!
         */
        [Route("api/GetReservaciones_Procedimientos")]
        public async Task<ActionResult<IEnumerable<Reservacion_Procedimiento>>> Getreservacion_procedimiento()
        {
            /*
            //Query de SELECT de un View para obtener los datos necesarios para mostrar TODOS los historiales clinicos
            string query =
                "SELECT "
                + "idhistorial, " + "idpac, " + "nombrepaciente, " + "procedimiento, " + "tratam, " + "fechaProc, " + "dias "
                + "FROM "
                + "viewhistorial"
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vhistorial_clinico.FromSqlRaw(query).ToListAsync();
            */

            return await _context.reservacion_procedimiento.ToListAsync();
        }

        /*
         * GET: "api/GetReservacion_Procedimientos/idreservacion"
         * Obtiene todas las reservaciones_procedimientos de  UNA SOLA RESERVACION con el idreservacion indicado
         */
        [Route("api/GetReservacion_Procedimientos/{idreservacion}")]
        public async Task<ActionResult<IEnumerable<Reservacion_Procedimiento>>> Getreservacion_procedimiento(int idreservacion)
        {
            /*
             * //Query de SELECT de un View para obtener los datos necesarios para mostrar los historiales clinicos de un solo Paciente (idpaciente)
            string query =
                "SELECT "
                + "idhistorial, " + "idpac, " + "nombrepaciente, " + "procedimiento, " + "tratam, " + "fechaProc, " + "dias "
                + "FROM "
                + "viewhistorial "
                + "WHERE"
                + " idpac = " + idpaciente.ToString() + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vhistorial_clinico.FromSqlRaw(query).ToListAsync();
            */

            return await _context.reservacion_procedimiento.ToListAsync();
        }

        /*
         * GET: "api/GetReservacion_Procedimiento/idReservacionProcedimiento"
         * Obtiene solo la reservacion_procedimiento con el idreservacionprocedimiento indicado
         */
        [Route("api/GetReservacion_Procedimiento/{idreservacionprocedimiento}")]
        [HttpGet]
        public async Task<ActionResult<Reservacion_Procedimiento>> GetReservacion_Procedimiento(int idreservacionprocedimiento)
        {                          //Cambiar returnType
            /*
            //Query de SELECT de un View para obtener los datos necesarios para mostrar un historial clinico (idhistorial)
            string query =
                "SELECT "
                + "idhistorial, " + "idpac, " + "nombrepaciente, " + "procedimiento, " + "tratam, " + "fechaProc, " + "dias "
                + "FROM "
                + "viewhistorial "
                + "WHERE"
                + " idhistorial = " + idhistorial.ToString() + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vhistorial_clinico.FromSqlRaw(query).ToListAsync();
            */

            var reservacion_Procedimiento = await _context.reservacion_procedimiento.FindAsync(idreservacionprocedimiento);

            if (reservacion_Procedimiento == null)
            {
                return NotFound();
            }

            return reservacion_Procedimiento;
        }

        /*
         * PUT: "api/PutReservacion_Procedimiento"
         * Actualiza una reservacion_procedimiento con el idreservacionprocedimiento que se indica en el Form.
         */
        [Route("api/PutReservacion_Procedimiento")]
        [HttpPut]
        public async Task<IActionResult> PutReservacion_Procedimiento([FromBody] Reservacion_Procedimiento reservacion_Procedimiento)
        {
            /*if (idreservacionprocedimiento != reservacion_Procedimiento.idreservacion)
            {
                return BadRequest();
            }*/

            _context.Entry(reservacion_Procedimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reservacion_ProcedimientoExists(reservacion_Procedimiento.idreservacionprocedimiento))
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
         * POST: "api/PostReservacion_Procedimiento"
         * Agregar una reservacion_procedimiento nueva a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostReservacion_Procedimiento")]
        [HttpPost]
        public async Task<ActionResult<Reservacion_Procedimiento>> PostReservacion_Procedimiento(Reservacion_Procedimiento reservacion_Procedimiento)
        {
            _context.reservacion_procedimiento.Add(reservacion_Procedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservacion_Procedimiento", new { id = reservacion_Procedimiento.idreservacionprocedimiento }, reservacion_Procedimiento);
        }

        /*
         * DELETE: "api/DeleteReservacion_Procedimiento/idReservacionProcedimiento"
         * Elimina de la base de datos la reservacion_procedimiento con el idreservacionprocedimiento indicado
         */
        [Route("api/DeleteReservacion_Procedimiento/{idreservacionprocedimiento}")]
        [HttpDelete]
        public async Task<ActionResult<Reservacion_Procedimiento>> DeleteReservacion_Procedimiento(int idreservacionprocedimiento)
        {
            var reservacion_Procedimiento = await _context.reservacion_procedimiento.FindAsync(idreservacionprocedimiento);
            if (reservacion_Procedimiento == null)
            {
                return NotFound();
            }

            _context.reservacion_procedimiento.Remove(reservacion_Procedimiento);
            await _context.SaveChangesAsync();

            return reservacion_Procedimiento;
        }

        private bool Reservacion_ProcedimientoExists(int idreservacionprocedimiento)
        {
            return _context.reservacion_procedimiento.Any(e => e.idreservacionprocedimiento == idreservacionprocedimiento);
        }
    }
}
