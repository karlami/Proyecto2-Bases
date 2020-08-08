using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa a los Salones del Hospital
     * El Personal puede ingresar, modificar y eliminar salones.
     */
    public class Salon
    {
        public Salon()
        {
        }

        [Key]
        public int numerosalon { get; set; }
        public string nombre { get; set; }
        public int cantidadcama { get; set; }
        public int numeropiso { get; set; }
        public int idtiposalon { get; set; }
    }
}
