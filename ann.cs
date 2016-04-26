using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANN
{
    class ann
    {
        Neuron I1,I2,H1, H2,O;

        public ann()
        {
            I1 = new Neuron(Normalize.get(-2, 2, 0), null);
            I2 = new Neuron(Normalize.get(-5, 5, 0), null);

            Connection[] ch1 = new Connection[2];
            ch1[0] = new Connection();
            ch1[0].Input_value = I1.Value;
            ch1[0].Weight_value = 0;
            ch1[1] = new Connection();
            ch1[1].Input_value = I2.Value;
            ch1[1].Weight_value = 0;
            H1 = new Neuron((ch1[0].Input_value * ch1[0].Weight_value) + (ch1[1].Input_value * ch1[1].Weight_value), ch1);
            H1.Value = Sigmoid.get(H1.Value);

            Connection[] ch2 = new Connection[2];
            ch2[0] = new Connection();
            ch2[0].Input_value = I1.Value;
            ch2[0].Weight_value = 0;
            ch2[1] = new Connection();
            ch2[1].Input_value = I2.Value;
            ch2[1].Weight_value = 0;
            H2 = new Neuron((ch2[0].Input_value * ch2[0].Weight_value) + (ch2[1].Input_value * ch2[1].Weight_value), ch2);
            H2.Value = Sigmoid.get(H2.Value);

            Connection[] co = new Connection[2];
            co[0] = new Connection();
            co[0].Input_value = H1.Value;
            co[0].Weight_value = 0;
            co[1] = new Connection();
            co[1].Input_value = H2.Value;
            co[1].Weight_value = 0;
            O = new Neuron((co[0].Input_value * co[0].Weight_value) + (co[1].Input_value * co[1].Weight_value), co);
            O.Value = Sigmoid.get(O.Value);
        }

     public  void learn(double x,double y,double fitness)
        {
            double nfitness=Normalize.get(0,29,fitness);
            random R = new random(-0.5, 0.5);
            double n = 0.1;

            I1.Value = Normalize.get(-2, 2, x);
            I2.Value = Normalize.get(-5, 5, y);

            H1.Input_weights[0].Input_value = I1.Value;
            H1.Input_weights[0].Weight_value = R.next();
            H1.Input_weights[1].Input_value = I2.Value;
            H1.Input_weights[1].Weight_value = R.next();

            H2.Input_weights[0].Input_value = I1.Value;
            H2.Input_weights[0].Weight_value = R.next();
            H2.Input_weights[1].Weight_value = I2.Value;
            H2.Input_weights[1].Weight_value = R.next();

            while (true)
            {
                H1.Value = 0;
                H2.Value = 0;

                for (int i = 0; i < H1.Input_weights.Length; i++)
                {
                    H1.Value += H1.Input_weights[i].Input_value * H1.Input_weights[i].Weight_value;
                    H2.Value += H2.Input_weights[i].Input_value * H2.Input_weights[i].Weight_value;
                }
                H1.Value = Sigmoid.get(H1.Value);
                H2.Value = Sigmoid.get(H2.Value);

                O.Input_weights[0].Input_value = H1.Value;
                O.Input_weights[0].Weight_value = R.next();
                O.Input_weights[1].Input_value = H2.Value;
                O.Input_weights[1].Weight_value = R.next();

                O.Value = 0;
                for (int i = 0; i < O.Input_weights.Length; i++)
                {
                    O.Value += O.Input_weights[i].Input_value * O.Input_weights[i].Weight_value;
                }

                O.Value = Sigmoid.get(O.Value);

                double eO = O.Value * (nfitness - O.Value) * (1 - O.Value);
                if (eO ==0)
                    break;
                Console.WriteLine(eO);
                double eH1 = (eO * O.Input_weights[0].Weight_value) * (H1.Value * (1 - H1.Value));
                double eH2 = (eO * O.Input_weights[1].Weight_value) * (H2.Value * (1 - H2.Value));

                H1.Input_weights[0].Weight_value += (n * eH1 * I1.Value);
                H1.Input_weights[1].Weight_value += (n * eH1 * I2.Value);

                H2.Input_weights[0].Weight_value += (n * eH2 * I1.Value);
                H2.Input_weights[1].Weight_value += (n * eH2 * I2.Value);

                O.Input_weights[0].Weight_value += (n * eO * H1.Value);
                O.Input_weights[1].Weight_value += (n * eO * H2.Value);
            }
        }
    }
}
