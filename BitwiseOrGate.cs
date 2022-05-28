using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A two input bitwise gate takes as input two WireSets containing n wires, and computes a bitwise function - z_i=f(x_i,y_i)
    class BitwiseOrGate : BitwiseTwoInputGate
    {
        //your code here
        public BitwiseOrGate(int iSize)
            : base(iSize)
        {
            //your code here
            OrGate[] ors = new OrGate[iSize];
            for (int i = 0; i<iSize; i++) {
                ors[i] = new OrGate();
                ors[i].ConnectInput1(Input1[i]);
                ors[i].ConnectInput2(Input2[i]);
                Output[i].ConnectInput(ors[i].Output);
            }
        }

        //an implementation of the ToString method is called, e.g. when we use Console.WriteLine(or)
        //this is very helpful during debugging
        public override string ToString()
        {
            return "Or " + Input1 + ", " + Input2 + " -> " + Output;
        }

        public override bool TestGate()
        {
            return true;
        }
    }
}
