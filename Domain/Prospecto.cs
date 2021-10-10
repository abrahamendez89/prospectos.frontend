using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Domain;

namespace Domain
{
    public class Prospecto:DomainObject
    {
        public int prospecto_id { get; set; }
        [DCValidateCondition(StringMaxSize = 50, IsRequired = true)]
        public String prospecto_nombre { get; set; }
        [DCValidateCondition(StringMaxSize = 50, IsRequired = true)]
        public String prospecto_appaterno { get; set; }
        [DCValidateCondition(StringMaxSize = 50)]
        public String prospecto_apmaterno { get; set; }
        [DCValidateCondition(StringMaxSize = 100, IsRequired = true)]
        public String prospecto_calle { get; set; }
        [DCValidateCondition(StringMaxSize = 10, IsRequired = true)]
        public String prospecto_numero { get; set; }
        [DCValidateCondition(StringMaxSize = 50, IsRequired = true)]
        public String prospecto_colonia { get; set; }
        [DCValidateCondition(StringMinSize = 5, StringMaxSize = 5, IsRequired = true)]
        public String prospecto_cod_postal { get; set; }
        [DCValidateCondition(StringMinSize = 10, StringMaxSize = 10, IsRequired = true)]
        public String prospecto_tel { get; set; }
        [DCValidateCondition(StringMinSize = 10, StringMaxSize = 13, IsRequired = true)]
        public String prospecto_RFC { get; set; }
        [DCValidateCondition(StringMaxSize = 45, IsRequired = true)]
        public String prospecto_estatus { get; set; }

        [DCValidateCondition(StringMaxSize = 200)]
        public String prospecto_observaciones { get; set; }
    }
}
