using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class Connection
    {
        double input_value, weight_value;

        public double Weight_value
        {
            get { return weight_value; }
            set { weight_value = value; }
        }

        public double Input_value
        {
            get { return input_value; }
            set { input_value = value; }
        }

    }
}
