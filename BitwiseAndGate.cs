using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A two input bitwise gate takes as input two WireSets containing n wires, and computes a bitwise function - z_i=f(x_i,y_i)
    class BitwiseAndGate : BitwiseTwoInputGate
    {
        //your code here 
        public BitwiseAndGate(int iSize)
            : base(iSize)
        {
            //your code here
            AndGate[] ands = new AndGate[iSize];
            for (int i = 0; i<iSize; i++) {
                ands[i] = new AndGate();
                ands[i].ConnectInput1(Input1[i]);
                ands[i].ConnectInput2(Input2[i]);
                Output[i].ConnectInput(ands[i].Output);
            }
        }

        //an implementation of the ToString method is called, e.g. when we use Console.WriteLine(and)
        //this is very helpful during debugging
        public override string ToString()
        {
            return "And " + Input1 + ", " + Input2 + " -> " + Output;
        }



        public override bool TestGate()
        {
            return true;
        }
    }
}
