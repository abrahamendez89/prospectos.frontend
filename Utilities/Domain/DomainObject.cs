using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Domain
{
    public abstract class DomainObject
    {
        public void DCValidate()
        {
            foreach(PropertyInfo pi in this.GetType().GetProperties())
            {
                foreach(Attribute at in pi.GetCustomAttributes())
                {
                    if(at.GetType() == typeof(DCValidateCondition))
                    {
                        DCValidateCondition dv = (DCValidateCondition)at;
                        if(dv.IsRequired && (pi.GetValue(this) == null || pi.GetValue(this).ToString().Trim().Equals("") ))
                        {
                            throw new Exception("El campo es requerido [ " + pi.Name + " ]");
                        }
                        if (!dv.IsRequired && pi.GetValue(this) == null)
                        {
                            continue;
                        }
                        if (pi.PropertyType == typeof(String) && (pi.GetValue(this).ToString().Length < dv.StringMinSize || pi.GetValue(this).ToString().Length > dv.StringMaxSize))
                        {
                            throw new Exception("El tamaño de la cadena es diferente al establecido [ "+pi.Name+" ("+dv.StringMinSize+"-"+ dv.StringMaxSize + ")]");
                        }
                        if (pi.PropertyType == typeof(int) && ((int)pi.GetValue(this) < dv.IntMinValue || (int)pi.GetValue(this) > dv.IntMaxValue))
                        {
                            throw new Exception("El valor esta fuera de los rangos [ "+pi.Name+" fuera de (" + dv.IntMinValue + "-"+ dv.IntMaxValue + ")]");
                        }
                    }
                }
            }
        }
    }
}
