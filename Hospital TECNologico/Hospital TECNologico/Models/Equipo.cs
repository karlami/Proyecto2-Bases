using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa al Equipo Medico usado en las camas del Hospital
     * El Personal puede ingresar y modificar equipo medico.
     */
    public class Equipo
    {
        public Equipo()
        {
        }

        [Key]
        public int idequipo { get; set; }
        public string nombre { get; set; }
        public string proveedor { get; set; }
        public int cantidad { get; set; }
    }
}
