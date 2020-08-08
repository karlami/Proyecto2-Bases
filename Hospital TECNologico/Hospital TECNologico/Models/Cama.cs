using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa las camas dentro de los salones del hopital,
     * estamas camas tendran su propio equipo medico.
     * Pueden ser UCI o no.
     * El Personal puede ingresar y modificar camas.
     */
    public class Cama
    {
        public Cama()
        {
        }

        [Key]
        public int numerocama { get; set; }
        public bool uci { get; set; }
        public int idequipo { get; set; }
        public int idsalon { get; set; }
    }
}
