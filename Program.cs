using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class Program
    {
        static void Main(string[] args)
        {
            ann annobj = new ann();
            annobj.learn(1, 2, 5);
        }
    }
}
