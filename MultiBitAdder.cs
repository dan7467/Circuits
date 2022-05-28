using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This class implements an adder, receving as input two n bit numbers, and outputing the sum of the two numbers
    class MultiBitAdder : Gate
    {
        //Word size - number of bits in each input
        public int Size { get; private set; }

        public WireSet Input1 { get; private set; }
        public WireSet Input2 { get; private set; }
        public WireSet Output { get; private set; }
        //An overflow bit for the summation computation
        public Wire Overflow { get; private set; }


        public MultiBitAdder(int iSize)
        {
            Size = iSize;
            Input1 = new WireSet(Size);
            Input2 = new WireSet(Size);
            Output = new WireSet(Size);
            //your code here
            Overflow = new Wire();
            FullAdder[] adders = new FullAdder[iSize];
            for (int i=0; i<adders.Length; i++) {adders[i]=new FullAdder();}
                adders[0].ConnectInput1(Input1[0]);
                adders[0].ConnectInput2(Input2[0]);
                adders[0].CarryInput.Value = 0;
                Output[0].ConnectInput(adders[0].Output);
            for (int i = 1; i<adders.Length; i++) {
                // actions to do on full adder: connect inputs 1,2 (x,y), then Cin, Cout
                adders[i].ConnectInput1(Input1[i]);
                adders[i].ConnectInput2(Input2[i]);
                adders[i].CarryInput.ConnectInput(adders[i-1].CarryOutput);
                Output[i].ConnectInput(adders[i].Output);
            }
                Overflow.ConnectInput(adders[adders.Length-1].CarryOutput);
        }

        public override string ToString()
        {
            return Input1 + "(" + Input1.Get2sComplement() + ")" + " + " + Input2 + "(" + Input2.Get2sComplement() + ")" + " = " + Output + "(" + Output.Get2sComplement() + ")";
        }

        public void ConnectInput1(WireSet wInput)
        {
            Input1.ConnectInput(wInput);
        }
        public void ConnectInput2(WireSet wInput)
        {
            Input2.ConnectInput(wInput);
        }


        public override bool TestGate()
        {
            return true;
        }
    }
}
