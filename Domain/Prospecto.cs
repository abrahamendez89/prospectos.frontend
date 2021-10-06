using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Domain;

namespace Domain
{
    public class Prospecto
    {
        public int prospecto_id { get; set; }
        public String prospecto_nombre { get; set; }
        public String prospecto_appaterno { get; set; }
        public String prospecto_apmaterno { get; set; }
        public String prospecto_calle { get; set; }
        public String prospecto_numero { get; set; }
        public String prospecto_colonia { get; set; }
        public int prospecto_cod_postal { get; set; }
        [DCValidateCondition(Size = 10)]
        public String prospecto_tel { get; set; }
        public String prospecto_RFC { get; set; }
        public String prospecto_estatus { get; set; }
    }
}
