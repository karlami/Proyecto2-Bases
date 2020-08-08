using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa a los procedimientos que el Paciente
     * hara un reservacion para que se le lleven a cabo.
     * El Paciente puede ingresar, mostrar, modificar y eliminar 
     * los procedimientos de las reservaciones.
     */
    public class Reservacion_Procedimiento
    {
        public Reservacion_Procedimiento()
        {
        }

        [Key]
        public int idreservacion_procedimiento { get; set; }
        public int idreservacion { get; set; }
        public int idprocedimiento { get; set; }
    }
}
