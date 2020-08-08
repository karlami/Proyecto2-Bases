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
     * Controlador de Direccion
     * Recibe las solicitudes para Mostrar estos de la base de datos.
     */
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly HospitalTECNologicoContext _context;

        public DireccionesController(HospitalTECNologicoContext context)
        {
            _context = context;
        }

        /*
         * GET: "api/GetDirecciones"
         * Obtiene todas las direcciones en la base de datos
         */
        [Route("api/GetDirecciones")]
        public async Task<ActionResult<IEnumerable<Direccion>>> Getdireccion()
        {
            //Query de SELECT de un View para obtener las ubicaciones y mostrar un string completo de toda la direccion
            string query =
                "SELECT "
                + "iddireccion, " + "direccion "
                + "FROM "
                + "viewDireccion"
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.direccion.FromSqlRaw(query).ToListAsync();
        }

        /*
         * GET: "api/GetDireccione/iddireccion"
         * Obtiene todas las direcciones en la base de datos
         */
        [Route("api/GetDireccion/{iddireccion}")]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccion(int iddireccion)
        {
            //Query de SELECT de un View para obtener la ubicacion especifica y mostrar un string completo de toda la direccion
            string query =
                "SELECT "
                + "iddireccion, " + "direccion "
                + "FROM "
                + "viewDireccion "
                + "WHERE "
                + "iddireccion = " + iddireccion.ToString()
                + ";";

            //Retorna todos los objetos obtenidos del view de historial_clinico
            return await _context.direccion.FromSqlRaw(query).ToListAsync();
        }

        private bool DireccionExists(int id)
        {
            return _context.direccion.Any(e => e.iddireccion == id);
        }
    }
}
