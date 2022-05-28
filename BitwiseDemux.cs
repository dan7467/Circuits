using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A bitwise gate takes as input WireSets containing n wires, and computes a bitwise function - z_i=f(x_i)
    class BitwiseDemux : Gate
    {
        public int Size { get; private set; }
        public WireSet Output1 { get; private set; }
        public WireSet Output2 { get; private set; }
        public WireSet Input { get; private set; }
        public Wire Control { get; private set; }

        //your code here
        public BitwiseDemux(int iSize)
        {
            Size = iSize;
            Control = new Wire();
            Input = new WireSet(Size);

            //your code here
            Output1 = new WireSet(Size);
            Output2 = new WireSet(Size);
            Demux[] dmuxs = new Demux[Size];

            for (int i = 0; i<iSize; i++) {
                dmuxs[i] = new Demux();
                dmuxs[i].ConnectInput(Input[i]);
                dmuxs[i].ConnectControl(Control);
                Output1[i].ConnectInput(dmuxs[i].Output1);
                Output2[i].ConnectInput(dmuxs[i].Output2);
            }
        }

        public void ConnectControl(Wire wControl)
        {
            Control.ConnectInput(wControl);
        }
        public void ConnectInput(WireSet wsInput)
        {
            Input.ConnectInput(wsInput);
        }

        public override bool TestGate()
        {
            return true;
        }
    }
}
