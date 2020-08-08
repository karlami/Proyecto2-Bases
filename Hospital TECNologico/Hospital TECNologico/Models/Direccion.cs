using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa las direcciones que tienen asignados
     * las personas.
     */
    public class Direccion
    {
        public Direccion()
        {
        }

        [Key]
        public int iddireccion { get; set; }
        public string direccion { get; set; }
    }
}
