using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa las reservaciones de camas que haran
     * los pacientes para que puedan llevarse a cabo un
     * procedimiento en el hospital. Estos escogen su
     * fecha de inicio y la fecha de salida se calcula
     * en base a los procedimientos que sean seleccionados.
     * El Paciente puede ingresar, mostrar, modificar y eliminar reservaciones.
     */
    public class Reservacion
    {
        public Reservacion()
        {
        }

        [Key]
        public int idreservacion { get; set; }
        public DateTime fechaingreso { get; set; }
        public DateTime fechasalida { get; set; }
        public int idpaciente { get; set; }
        public int idcama { get; set; }
        
    }
}
