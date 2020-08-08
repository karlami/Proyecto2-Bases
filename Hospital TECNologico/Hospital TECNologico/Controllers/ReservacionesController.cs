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
     * Controlador de Reservacion
     * Recibe las solicitudes para Ingresar, Mostrar, Modificar y Eliminar estos de la base de datos.
     */
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de ReservacionesController
         */
        public ReservacionesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetReservaciones"
         * Obtiene todas las reservaciones en la base de datos
         */
        [Route("api/GetReservaciones")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> Getreservacion()
        {
            return await _context.reservacion.ToListAsync();
        }

        /*
         * GET: "api/GetReservaciones/idPaciente"
         * Obtiene todas las reservaciones de UN SOLO PACIENTE con el idpaciente indicado
         */
        [Route("api/GetReservaciones/{idpaciente}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> Getreservacion(int idpaciente)
        {
            //Query de SELECT de la tabla reervaciones para obtener los datos necesarios para mostrar las reservaciones de un solo Paciente (idpaciente)
            string query =
                "SELECT "
                + "idreservacion, " + "fechaingreso, " + "fechasalida, " + "idpaciente, " + "idcama "
                + "FROM "
                + "reservacion "
                + "WHERE"
                + " idpaciente = " + idpaciente.ToString() + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.reservacion.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetReservacion/idpacientepatologia"
         * Obtiene solo la reservacion con el idreservacion indicado
         */
        [Route("api/GetReservacion/{idreservacion}")]
        [HttpGet]
        public async Task<ActionResult<Reservacion>> GetReservacion(int idreservacion)
        {
            var reservacion = await _context.reservacion.FindAsync(idreservacion);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        /*
         * PUT: "api/PutReservacion"
         * Actualiza una reservacion con el idpaciente que se indica en el Form.
         */
        [Route("api/PutReservacion")]
        [HttpPut]
        public async Task<IActionResult> PutReservacion([FromBody] Reservacion reservacion)
        {
            /*if (id != reservacion.idreservacion)
            {
                return BadRequest();
            }*/

            _context.Entry(reservacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionExists(reservacion.idreservacion))
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
         * POST: "api/PostReservacion"
         * Agregar una reservacion nueva a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostReservacion")]
        [HttpPost]
        public async Task<ActionResult<Reservacion>> PostReservacion([FromBody] Reservacion reservacion)
        {
            //Escoger la cama
            reservacion.idcama = 4; //CAMBIAR
            //Calcular la fecha de salida
            /*var dateString = "04/01/1992"; //CAMBIAR
            DateTime date1 = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            reservacion.fechasalida = date1;*/
            //Fecha de salida, al ingresarse por primera vez la reservacion deberia ser igual a
            //fechainicial para luego cambiarse cuando se calcule.
            reservacion.fechasalida = reservacion.fechaingreso;


            _context.reservacion.Add(reservacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservacion", new { id = reservacion.idreservacion }, reservacion);
        }

        /*
         * DELETE: "api/DeleteReservacion/idreservacion"
         * Elimina de la base de datos la reservacion con el idreservacion indicado
         */
        [Route("api/DeleteReservacion/{idreservacion}")]
        [HttpDelete]
        public async Task<ActionResult<Reservacion>> DeleteReservacion(int idreservacion)
        {
            var reservacion = await _context.reservacion.FindAsync(idreservacion);
            if (reservacion == null)
            {
                return NotFound();
            }

            _context.reservacion.Remove(reservacion);
            await _context.SaveChangesAsync();

            return reservacion;
        }

        private bool ReservacionExists(int idreservacion)
        {
            return _context.reservacion.Any(e => e.idreservacion == idreservacion);
        }
    }
}
