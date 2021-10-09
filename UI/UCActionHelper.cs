using Meziantou.WpfFontAwesome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UCActionHelper : Attribute
    {
        public String UCNombreAccion { get; set; }
        public String UCRol { get; set; }
        public FontAwesomeSolidIcon UCIcon { get; set; }
    }
}
