using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //This class is used to implement the ALU
    class ALU : Gate
    {
        //The word size = number of bit in the input and output
        public int Size { get; private set; }

        //Input and output n bit numbers
        //inputs
        public WireSet InputX { get; private set; }
        public WireSet InputY { get; private set; }
        public WireSet Control { get; private set; }

        //outputs
        public WireSet Output { get; private set; }
        public Wire Zero { get; private set; }
        public Wire Negative { get; private set; }


        //your code here
        //Dan: in order to built the alu i used https://www.youtube.com/watch?v=lvYCchzQTyE
        BitwiseMux mux1, mux2, mux3;
        BitwiseNotGate not1, not2, not3;
        MultiBitAdder mbt;
        BitwiseAndGate btag1, btag2;
        BitwiseOrGate btog1;
        BitwiseXorGate btxg1;
        public ALU(int iSize)
        {
            Size = iSize;
            InputX = new WireSet(Size);
            InputY = new WireSet(Size);
            Control = new WireSet(6);
            Zero = new Wire();
            
            //Create and connect all the internal components
            mux1 = new BitwiseMux(Size);
            not1 = new BitwiseNotGate(Size);
            mux2 = new BitwiseMux(Size);
            not2 = new BitwiseNotGate(Size);
            not3 = new BitwiseNotGate(Size);
            mbt = new MultiBitAdder(Size);
            mux3 = new BitwiseMux(Size);
            btag1 = new BitwiseAndGate(Size);
            btag2 = new BitwiseAndGate(Size);
            btog1 = new BitwiseOrGate(Size);
            btxg1 = new BitwiseXorGate(Size);

            mux1.ConnectInput1(InputX);
            not1.ConnectInput(InputX); 
            mux1.ConnectInput2(not1.Output);

            mux2.ConnectInput1(InputY);
            not2.ConnectInput(InputY); 
            mux2.ConnectInput2(not2.Output);

            mbt.ConnectInput1(mux1.Output);
            mbt.ConnectInput2(mux2.Output);

            mux3.ConnectInput1(mbt.Output);

            btag1.ConnectInput1(InputX);
            btag1.ConnectInput2(InputY);

            not3.ConnectInput(InputY);

            btag2.ConnectInput1(InputX);
            btag2.ConnectInput2(not3.Output);

            btog1.ConnectInput1(InputX);
            btog1.ConnectInput2(InputY);
            
            btxg1.ConnectInput1(InputX);
            btxg1.ConnectInput2(InputY);

            // Control[0].ConnectInput(btag1.Output);
            // Control[1].ConnectInput(btag2.Output);
            // Control[2].ConnectInput(btog1.Output);
            // Control[3].ConnectInput(btxg1.Output);
            // Control[4].ConnectInput(InputY);
            // Control[5].ConnectInput(not3.Output);

            
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}
