using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A two input bitwise gate takes as input two WireSets containing n wires, and computes a bitwise function - z_i=f(x_i,y_i)
    class BitwiseXorGate : BitwiseTwoInputGate
    {
        //your code here
        public BitwiseXorGate(int iSize)
            : base(iSize)
        {
            //your code here
            XorGate[] xors = new XorGate[iSize];
            for (int i = 0; i<iSize; i++) {
                xors[i] = new XorGate();
                xors[i].ConnectInput1(Input1[i]);
                xors[i].ConnectInput2(Input2[i]);
                Output[i].ConnectInput(xors[i].Output);
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
