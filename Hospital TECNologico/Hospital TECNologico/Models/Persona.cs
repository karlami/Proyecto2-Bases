using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa a una Persona
     * Estos atributos son usados por Paciente y Empleado.
     * Esta clase no se usa directamente para guardar en la base de datos,
     * solo si es necesario un atributo especifico de Persona.
     */
    public class Persona
    {
        public Persona()
        {
        }

        [Key]
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string primerapellido { get; set; }
        public string segundoapellido { get; set; }
        public int telefono { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string contrasena { get; set; }
        public int iddireccion { get; set; }
    }
}
