using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class Sigmoid
    {
        public static double get(double x)
        {
            return 1 / (1 + (Math.Pow(Math.E, -x)));
        }
    }
}
