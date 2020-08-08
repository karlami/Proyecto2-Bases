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
        //DbContext
        private readonly HospitalTECNologicoContext _context;

        /*
         * Constructor de CamasController
         */
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





            /*
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idreservacion, " + "fechaingreso, " + "fechasalida, " + "idpaciente, " + "idcama "
                + "FROM "
                + "reservacion " + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
            */







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






            /*
            //Query de SELECT del view VIEWPACIENTE para obtener los datos necesarios para mostrar todos los pacientes
            string query =
                "SELECT "
                + "idreservacion, " + "fechaingreso, " + "fechasalida, " + "idpaciente, " + "idcama "
                + "FROM "
                + "reservacion " + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.vpaciente.FromSqlRaw(query).ToListAsync();
            */






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
        public async Task<ActionResult<Cama>> PutCama([FromBody] Cama cama)
        {
            //Query para llamar al Stored Procedure de Empleado y Actualizar las tablas que necesita
            string query = "CALL modificarCama("
                + cama.numerocama.ToString() + ", "
                + cama.uci.ToString() + ", "
                + cama.idequipo.ToString() + ", "
                + cama.idsalon.ToString() + ", "
                + "'Update'" + "); ";

            //Corre el query
            await _context.Database.ExecuteSqlRawAsync(query);

            return cama;
        }

        /*
         * POST: "api/PostCama"
         * Agregar una cama nueva a la base de datos con la informacion que se indica en el Form.
         */
        [Route("api/PostCama")]
        [HttpPost]
        public async Task<ActionResult<Cama>> PostCama([FromBody] Cama cama)
        {
            //Query para llamar al Stored Procedure de Empleado e Insertar en las tablas que necesita
            string query = "CALL modificarCama("
                + cama.numerocama.ToString() + ", "
                + cama.uci.ToString() + ", "
                + cama.idequipo.ToString() + ", "
                + cama.idsalon.ToString() + ", "
                + "'Insert'" + "); ";

            //Corre el query
            await _context.Database.ExecuteSqlRawAsync(query);

            return cama;
        }

        /*
         * DELETE: "api/DeleteCama/numeroCama"
         * Elimina de la base de datos la cama con el numerocama indicado
         * No necesario por especificacion!
         */
        /*[Route("api/DeleteCama/{numerocama}")]
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
        }*/

        private bool CamaExists(int numerocama)
        {
            return _context.cama.Any(e => e.numerocama == numerocama);
        }
    }
}
