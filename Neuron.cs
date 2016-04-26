using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class Neuron
    {
        Connection[] input_weights;

        public Connection[] Input_weights
        {
            get { return input_weights; }
            set { input_weights = value; }
        }
        double value;

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Neuron(double val, Connection[] w)
        {
            value = val;
            input_weights = w;
        }

        public void display()
        {
            Console.WriteLine(value);
        }
    }
}
