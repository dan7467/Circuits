using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A bitwise gate takes as input WireSets containing n wires, and computes a bitwise function - z_i=f(x_i)
    class BitwiseMux : BitwiseTwoInputGate
    {
        public Wire ControlInput { get; private set; }

        //your code here
        public BitwiseMux(int iSize)
            : base(iSize)
        {
            ControlInput = new Wire();
            //your code here
            MuxGate[] muxs = new MuxGate[iSize];
            for (int i = 0; i<iSize; i++) {
                muxs[i] = new MuxGate();
                muxs[i].ConnectInput1(Input1[i]);
                muxs[i].ConnectInput2(Input2[i]);
                muxs[i].ConnectControl(ControlInput);
                Output[i].ConnectInput(muxs[i].Output);
            }
        }

        public void ConnectControl(Wire wControl)
        {
            ControlInput.ConnectInput(wControl);
        }



        public override string ToString()
        {
            return "Mux " + Input1 + "," + Input2 + ",C" + ControlInput.Value + " -> " + Output;
        }




        public override bool TestGate()
        {
            return true;
        }
    }
}
