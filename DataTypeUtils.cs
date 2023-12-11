using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public class DataTypeUtils
    {
        public void ConvertStringToDoubleRef(string str, ref double value)
        {
            if (double.TryParse(str, out double result))
            {
                value = result;
            }
            else
            {
                // Обработка некорректного значения
            }
        }
    }
}
