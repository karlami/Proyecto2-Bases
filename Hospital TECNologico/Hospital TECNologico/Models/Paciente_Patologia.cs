using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa la relación que tiene in paciente con
     * sus propias patologias. Cada una de ellas tiene
     * un tratamiento propio dependiendo del paciente.
     * El Paciente o los Doctores, al dar de alta el nuevo
     * Paciente, ingresan sus patologias propias.
     */
    public class Paciente_Patologia
    {
        public Paciente_Patologia()
        {
        }

        [Key]
        public int idpaciente { get; set; }
        public int idpatologia { get; set; }
        public string tratamiento { get; set; } 
    }
}
