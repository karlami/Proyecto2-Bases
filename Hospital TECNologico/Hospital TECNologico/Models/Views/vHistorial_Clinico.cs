using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class vHistorial_Clinico
    {
        public vHistorial_Clinico()
        {
        }

        [Key]
        public int idhistorial { get; set; }
        public int idpac { get; set; }
        public string procedimiento { get; set; }
        public string tratam { get; set; }
        public string nombrepaciente { get; set; }
        public DateTime fechaProc { get; set; }
        public int dias { get; set; }
    }
}
