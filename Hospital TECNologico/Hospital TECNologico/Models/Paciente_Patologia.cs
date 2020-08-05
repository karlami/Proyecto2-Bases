using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Paciente_Patologia
    {
        public Paciente_Patologia()
        {
        }

        //[Key]
        public int idpaciente { get; set; }
        public int idpatologia { get; set; }
        public string tratamiento { get; set; }
    }
}
