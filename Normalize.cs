using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class Normalize
    {
        public static double get(double min,double max,double value)
        {
            return (value-min)/(max-min);
        }
    }
}
