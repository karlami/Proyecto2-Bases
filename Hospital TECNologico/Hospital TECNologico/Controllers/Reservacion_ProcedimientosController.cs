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
        public async Task<ActionResult<IEnumerable<vReservacion_Procedimiento>>> Getreservacion_procedimiento()
        {
            //Query de SELECT de un View para obtener los datos necesarios para mostrar TODOS los historiales clinicos
            string query =
                "SELECT "
                + "idreservacion_procedimiento, " + "idreservacion, " + "idprocedimiento, " + "nombre, " + "diasrecuperacion "
                + "FROM "
                + "viewReservacion_procedimiento "
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vreservacion_procedimiento.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetReservacion_Procedimientos/idreservacion"
         * Obtiene todas las reservaciones_procedimientos de UNA SOLA RESERVACION con el idreservacion indicado
         */
        [Route("api/GetReservacion_Procedimientos/{idreservacion}")]
        public async Task<ActionResult<IEnumerable<vReservacion_Procedimiento>>> Getreservacion_procedimiento(int idreservacion)
        {
            //Query de SELECT de un View para obtener los datos necesarios para mostrar TODOS los historiales clinicos
            string query =
                "SELECT "
                + "idreservacion_procedimiento, " + "idreservacion, " + "idprocedimiento, " + "nombre, " + "diasrecuperacion "
                + "FROM "
                + "viewReservacion_procedimiento "
                + "WHERE "
                + "idreservacion = " + idreservacion.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vreservacion_procedimiento.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetReservacion_Procedimiento/idreservacion_procedimiento"
         * Obtiene solo la reservacion_procedimiento con el idreservacion_procedimiento indicado
         */
        [Route("api/GetReservacion_Procedimiento/{idreservacion_procedimiento}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vReservacion_Procedimiento>>> GetReservacion_Procedimiento(int idreservacion_procedimiento)
        {
            //Query de SELECT de un View para obtener los datos necesarios para mostrar TODOS los historiales clinicos
            string query =
                "SELECT "
                + "idreservacion_procedimiento, " + "idreservacion, " + "idprocedimiento, " + "nombre, " + "diasrecuperacion "
                + "FROM "
                + "viewReservacion_procedimiento "
                + "WHERE "
                + "idreservacion_procedimiento = " + idreservacion_procedimiento.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vreservacion_procedimiento.FromSqlRaw(query).ToListAsync();
        }

        /*
         * PUT: "api/PutReservacion_Procedimiento"
         * Actualiza una reservacion_procedimiento con el idreservacion_procedimiento que se indica en el Form.
         */
        [Route("api/PutReservacion_Procedimiento")]
        [HttpPut]
        public async Task<IActionResult> PutReservacion_Procedimiento([FromBody] Reservacion_Procedimiento reservacion_Procedimiento)
        {
            /*if (idreservacion_procedimiento != reservacion_Procedimiento.idreservacion)
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
                if (!Reservacion_ProcedimientoExists(reservacion_Procedimiento.idreservacion_procedimiento))
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

            return CreatedAtAction("GetReservacion_Procedimiento", new { id = reservacion_Procedimiento.idreservacion_procedimiento }, reservacion_Procedimiento);
        }

        /*
         * DELETE: "api/DeleteReservacion_Procedimiento/idReservacionProcedimiento"
         * Elimina de la base de datos la reservacion_procedimiento con el idreservacion_procedimiento indicado
         */
        [Route("api/DeleteReservacion_Procedimiento/{idreservacion_procedimiento}")]
        [HttpDelete]
        public async Task<ActionResult<Reservacion_Procedimiento>> DeleteReservacion_Procedimiento(int idreservacion_procedimiento)
        {
            var reservacion_Procedimiento = await _context.reservacion_procedimiento.FindAsync(idreservacion_procedimiento);
            if (reservacion_Procedimiento == null)
            {
                return NotFound();
            }

            _context.reservacion_procedimiento.Remove(reservacion_Procedimiento);
            await _context.SaveChangesAsync();

            return reservacion_Procedimiento;
        }

        private bool Reservacion_ProcedimientoExists(int idreservacion_procedimiento)
        {
            return _context.reservacion_procedimiento.Any(e => e.idreservacion_procedimiento == idreservacion_procedimiento);
        }
    }
}
