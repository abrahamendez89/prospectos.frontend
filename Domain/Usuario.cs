using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Domain;

namespace Domain
{
    public class Usuario:DomainObject
    {
        [DCValidateCondition(StringSize = 5)]
        public String usuario_usuario { get; set; }
        public String usuario_contrasena { get; set; }
        public String usuario_rol { get; set; }
    }
}
