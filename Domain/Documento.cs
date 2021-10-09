using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Documento
    {
        public int documento_id { get; set; }
        public int prospecto_id { get; set; }
        public String documento_nombre_documento { get; set; }
        public String documento_data_base64 { get; set; }
    }
}
