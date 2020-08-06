using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa al Paciente
     * Tiene los atributos de Persona y se guarda su idpaciente en la tabla Paciente junto con la referencia a persona (cedula).
     */
    public class Paciente
    {
        public Paciente()
        {
        }

        [Key]
        public int idpaciente { get; set; }
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
