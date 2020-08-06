using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa el historial clinicos de un paciente.
     * Es una coleccion de los procedimientos que se
     * ha realizado un paciente, así como su tratamiento
     * propio y la fecha en la que se realizó.
     * Los Doctores pueden ingresar y modificar procedimientos.
     */
    public class Historial_Clinico
    {
        public Historial_Clinico()
        {
        }

        [Key]
        public int idhistorial { get; set; }
        public int idpaciente { get; set; }
        public int idprocedimiento { get; set; }
        public string tratamiento { get; set; }
        public DateTime fecha { get; set; }
    }
}
