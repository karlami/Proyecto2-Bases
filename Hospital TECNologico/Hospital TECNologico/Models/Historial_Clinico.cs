using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
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
