using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This class implements a FullAdder, taking as input 3 bits - 2 numbers and a carry, and computing the result in the output, and the carry out.
    class FullAdder : TwoInputGate
    {
        public Wire CarryInput { get; private set; }
        public Wire CarryOutput { get; private set; }

        //your code here
        HalfAdder h1, h2;
        AndGate and;
        public FullAdder()
        {
            CarryInput = new Wire();
            //your code here
            h1 = new HalfAdder();
            h2 = new HalfAdder();
            and = new AndGate();
            CarryInput = new Wire();
            CarryOutput = new Wire();
            Output = h2.Output;
            h1.ConnectInput1(Input1);
            h1.ConnectInput2(Input2);
            h2.ConnectInput1(h1.Output);
            h2.ConnectInput2(CarryInput);
            and.ConnectInput1(h1.CarryOutput);
            and.ConnectInput2(h2.CarryOutput);
            CarryOutput = and.Output;
        }


        public override string ToString()
        {
            return Input1.Value + "+" + Input2.Value + " (C" + CarryInput.Value + ") = " + Output.Value + " (C" + CarryOutput.Value + ")";
        }

        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            CarryInput.Value = 0;
             if (Output.Value != 0 | CarryOutput.Value != 0)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            CarryInput.Value = 0;
             if (Output.Value != 1 | CarryOutput.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            CarryInput.Value = 0;
             if (Output.Value != 1 | CarryOutput.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 0;
            CarryInput.Value = 1;
             if (Output.Value != 1 | CarryOutput.Value != 0)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            CarryInput.Value = 0;
             if (Output.Value != 0 | CarryOutput.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            CarryInput.Value = 1;
             if (Output.Value != 0 | CarryOutput.Value != 1)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            CarryInput.Value = 1;
             if (Output.Value != 0 | CarryOutput.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            CarryInput.Value = 1;
             if (Output.Value != 1 | CarryOutput.Value != 1)
                return false;
            return true;
        }
    }
}
