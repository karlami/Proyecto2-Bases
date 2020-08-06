using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    /*
     * Representa los procedimientos medicos que podran
     * ser ejecutados en los pacientes del hospital.
     * Estos incluyen su nombre y la cantidad de dias
     * que se necesitan para recuperarse.
     * El Personal puede ingresar y modificar procedimientos.
     */
    public class Procedimiento
    {
        public Procedimiento()
        {
        }

        [Key]
        public int idprocedimiento { get; set; }
        public string nombre { get; set; }
        public int diasrecuperacion { get; set; }
    }
}
