using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Canton
    {
        public Canton()
        {
        }

        [Key]
        public int idcanton { get; set; }
        public string canton { get; set; }
        public int idprovincia { get; set; }
    }
}
