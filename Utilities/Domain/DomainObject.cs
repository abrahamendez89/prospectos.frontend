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

                        if(pi.PropertyType == typeof(String) && pi.GetValue(this).ToString().Length > dv.StringSize)
                        {
                            throw new Exception("El tamaño de la cadena es superior al establecido ["+ dv.StringSize + "]");
                        }
                        if (pi.PropertyType == typeof(int) && ((int)pi.GetValue(this) < dv.IntMinValue || (int)pi.GetValue(this) > dv.IntMaxValue))
                        {
                            throw new Exception("El valor esta fuera de los rangos ["+ dv.IntMinValue + "-"+ dv.IntMaxValue + "]");
                        }
                    }
                }
            }
        }
    }
}
