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
        [DCValidateCondition(StringMaxSize = 45)]
        public String usuario_usuario { get; set; }
        [DCValidateCondition(StringMaxSize = 45)]
        public String usuario_contrasena { get; set; }
        [DCValidateCondition(StringMaxSize = 45)]
        public String usuario_rol { get; set; }
    }
}
