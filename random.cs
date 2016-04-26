using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class random
    {
        double max_value, min_value;
        Random rng;

        public random(double min_value, double max_value)
        {
            this.max_value = max_value;
            this.min_value = min_value;
            rng = new Random();
        }

        public double next()
        { return (min_value + (rng.NextDouble() * (max_value - min_value))); }
    }
}
